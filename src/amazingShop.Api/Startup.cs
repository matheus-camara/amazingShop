using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using amazingShop.Api.Localization;
using amazingShop.Api.Services.Users;
using amazingShop.Api.Settings;
using amazingShop.Domain.Core.Events;
using amazingShop.Domain.Core.Notifications;
using amazingShop.Domain.Entities;
using amazingShop.Domain.Repositories;
using amazingShop.Infra;
using amazingShop.Infra.Repositories.Events;
using amazingShop.Infra.Repositories.Products;
using amazingShop.Infra.Repositories.Users;
using Askmethat.Aspnet.JsonLocalizer.Extensions;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace amazingShop.Api
{
    public sealed class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(Configuration["SecuritySettings:SigningKey"])
                    )
                    };
                });


            var executingAssembly = Assembly.GetExecutingAssembly();
            var referencedAssemblies = executingAssembly.GetReferencedAssemblies().Select(a => Assembly.Load(a));
            var assemblies = new List<Assembly>();
            assemblies.Add(executingAssembly);
            assemblies.AddRange(referencedAssemblies);

            services.AddMediatR(assemblies.ToArray());

            services.AddAutoMapper(typeof(Startup));
            ConfigureDatabase(services);
            ConfigureRepositories(services);

            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddSingleton(x => new AppSettings(Configuration["SecuritySettings:SigningKey"]));

            services.AddJsonLocalization(options =>
            {
                options.CacheDuration = TimeSpan.FromDays(999);
                options.SupportedCultureInfos = new HashSet<CultureInfo>() {
                    new CultureInfo ("en-US"),
                    new CultureInfo ("pt-BR")
                };
            });

            services.AddControllers();
        }

        public void ConfigureRepositories(IServiceCollection services)
        {
            services.AddScoped<IRepository<Product>, ProductRepository>();
            services.AddScoped<IRepository<Event>, EventRepository>();
            services.AddScoped<IRepository<User>, UserRepository>();
            services.AddTransient<INotificationFactory, NotificationFactory>();
        }

        public void ConfigureDatabase(IServiceCollection services)
        {
            services.AddDbContext<ShopContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AmazingShopLocal")), ServiceLifetime.Scoped);
            services.AddDbContext<DbContext, ShopContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AmazingShopLocal")), ServiceLifetime.Scoped);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider provider, IHostApplicationLifetime applicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = new List<CultureInfo>()
                {
                    new CultureInfo ("en-US"),
                    new CultureInfo ("pt-BR")
                }
            });

            app.UseCors(options => options
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader()
            );

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}