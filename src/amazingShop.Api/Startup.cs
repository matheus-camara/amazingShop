using System;
using System.Collections.Generic;
using System.Globalization;
using amazingShop.Api.CommandHandlers.Products;
using amazingShop.Api.Dtos;
using amazingShop.Api.Localization;
using amazingShop.Api.Mappers;
using amazingShop.Api.Mappers.Products;
using amazingShop.Domain.Core.Commands;
using amazingShop.Domain.Core.Commands.Products;
using amazingShop.Domain.Core.Events;
using amazingShop.Domain.Core.Notifications;
using amazingShop.Domain.Entities;
using amazingShop.Domain.Events.Products;
using amazingShop.Domain.Repositories;
using amazingShop.Infra;
using amazingShop.Infra.Repositories.Products;
using Askmethat.Aspnet.JsonLocalizer.Extensions;
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
            ConfigureDatabase(services);
            ConfigureMappers(services);
            ConfigureCommandHandlers(services);
            ConfigureRepositories(services);
            ConfigureEvents(services);

            services.AddSingleton<ProductEventRegisterer>();
            services.AddJsonLocalization(options =>
            {
                options.CacheDuration = TimeSpan.FromDays(999);
                options.SupportedCultureInfos = new System.Collections.Generic.HashSet<CultureInfo>()
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("pt-BR")
                };
            });

            services.AddControllers();
        }

        public void ConfigureEvents(IServiceCollection services)
        {
            services.AddTransient<IEventHandler<ProductAddedEvent>, ProductAddedEventHandler>();
        }

        public void ConfigureRepositories(IServiceCollection services)
        {
            services.AddScoped<IRepository<Product>, ProductRepository>();
            services.AddTransient<INotificationFactory, NotificationFactory>();
        }

        public void ConfigureCommandHandlers(IServiceCollection services)
        {
            services.AddTransient<ICommandHandler<AddProductCommand>, AddProductCommandHandler>();
            services.AddTransient<ICommandHandler<GetProductCommand>, GetProductCommandHandler>();
            services.AddTransient<ICommandHandler<GetProductsCommand>, GetProductsCommandHandler>();
        }

        public void ConfigureMappers(IServiceCollection services)
        {
            services.AddTransient<IMapper<AddProductCommand, Product>, ProductMapper>();
            services.AddTransient<IMapper<Product, ProductDto>, ProductMapper>();
        }

        public void ConfigureDatabase(IServiceCollection services)
        {
            services.AddDbContext<ShopContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AmazingShop")));
            services.AddDbContext<DbContext, ShopContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AmazingShop")));
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
                    new CultureInfo("en-US"),
                    new CultureInfo("pt-BR")
                }
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            provider.GetRequiredService<ProductEventRegisterer>().Register();

            applicationLifetime.ApplicationStopping.Register(() => provider.GetRequiredService<ProductEventRegisterer>().Dispose());
        }
    }
}