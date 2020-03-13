using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using amazingShop.Api.Localization;
using amazingShop.Api.Mappers;
using amazingShop.Domain.Core.Events;
using amazingShop.Domain.Core.Notifications;
using amazingShop.Domain.Entities;
using amazingShop.Domain.Repositories;
using amazingShop.Infra;
using amazingShop.Infra.Repositories.Events;
using amazingShop.Infra.Repositories.Products;
using Askmethat.Aspnet.JsonLocalizer.Extensions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            var executingAssembly = Assembly.GetExecutingAssembly();
            var referencedAssemblies = executingAssembly.GetReferencedAssemblies().Select(a => Assembly.Load(a));
            var assemblies = new List<Assembly>();
            assemblies.Add(executingAssembly);
            assemblies.AddRange(referencedAssemblies);

            services.AddMediatR(assemblies.ToArray());
            ConfigureMappers.Build(services);
            ConfigureDatabase(services);
            ConfigureRepositories(services);

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
            services.AddTransient<INotificationFactory, NotificationFactory>();
        }

        public void ConfigureDatabase(IServiceCollection services)
        {
            services.AddDbContext<ShopContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AmazingShopLocal")));
            services.AddDbContext<DbContext, ShopContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AmazingShopLocal")));
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

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}