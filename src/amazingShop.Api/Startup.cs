using amazingShop.Api.CommandHandlers.Products;
using amazingShop.Api.Mappers;
using amazingShop.Api.Mappers.Products;
using amazingShop.Domain.Core.Commands;
using amazingShop.Domain.Core.Commands.Products;
using amazingShop.Domain.Core.Events;
using amazingShop.Domain.Entities;
using amazingShop.Domain.Events.Products;
using amazingShop.Domain.Repositories;
using amazingShop.Infra;
using amazingShop.Infra.Repositories.Products;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace amazingShop.Api
{
    public class Startup
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

            services.AddControllers();
        }

        public void ConfigureEvents(IServiceCollection services)
        {
            services.AddTransient<IEventHandler<ProductAddedEvent>, ProductAddedEventHandler>();
            services.AddSingleton<ProductEventRegisterer>();
        }

        public void ConfigureRepositories(IServiceCollection services)
        {
            services.AddTransient<IRepository<Product>, ProductRepository>(); 
        }

        public void ConfigureCommandHandlers(IServiceCollection services)
        {
            services.AddTransient<ICommandHandler<AddProductCommand>, AddProductCommandHandler>();
        }

        public void ConfigureMappers(IServiceCollection services)
        {
            services.AddTransient<IMapper<AddProductCommand, Product>, ProductMapper>();
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

            provider.GetRequiredService<ProductEventRegisterer>().Register();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            OnShutdown(provider, applicationLifetime);
        }

        private void OnShutdown(IServiceProvider provider, IHostApplicationLifetime applicationLifetime)
        {
            applicationLifetime.ApplicationStopping.Register(
                provider.GetRequiredService<ProductEventRegisterer>().Dispose
            );
        }
  }
}
