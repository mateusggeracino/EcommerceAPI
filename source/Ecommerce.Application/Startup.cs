using Ecommerce.Application.AutoMapper;
using Ecommerce.Application.Extensions;
using Ecommerce.Business;
using Ecommerce.Business.Interfaces;
using Ecommerce.Domain.Models;
using Ecommerce.Repository;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Services;
using Ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ecommerce.Application
{
    public class Startup
    {
        public Startup( IConfiguration configuration )
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// ConfigureServices AddMVc and Config swagger
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            DependencyInjection(services);
            services.SwaggerServices();
        }

        public void DependencyInjection( IServiceCollection services )
        {
            var mapperConfig = AutoMapperConfig.RegisterMappings( );
            services.AddSingleton( mapperConfig.CreateMapper( ) );

            DependencyInjectionBusiness( services );
            DependencyInjectionServices( services );
            DependencyInjectionRepository( services );
            services.BuildServiceProvider( );
        }

        /// <summary>
        /// Injeção de dependencia services
        /// </summary>
        /// <param name="services"></param>
        public void DependencyInjectionServices( IServiceCollection services )
        {
            services.AddTransient<IStockServices, StockServices>( );
            services.AddTransient<IClientServices, ClientServices>( );
            services.AddTransient<IPaymentMethodService, PaymentMethodService>( );
        }

        /// <summary>
        /// Injeção de dependencia Repository
        /// </summary>
        /// <param name="services"></param>
        public void DependencyInjectionRepository(IServiceCollection services)
        {
            services.AddSingleton<IStockRepository, StockRepository>( );
            services.AddSingleton<IPaymentMethodRepository, PaymentMethodRepository>( );
            services.AddSingleton<IRepository<Stock>, Repository<Stock>>();
            services.AddTransient<IClientRepository, ClientRepository>();
        }

        /// <summary>
        /// Injeção de dependencia Business
        /// </summary>
        /// <param name="services"></param>
        public void DependencyInjectionBusiness( IServiceCollection services )
        {
            services.AddTransient<IStockBusiness, StockBusiness>( );
            services.AddTransient<IClientBusiness, ClientBusiness>( );
            services.AddTransient<IPaymentMethodBusiness, PaymentMethodBusiness>( );
        }

        /// <summary>
        /// Método Configure startup. Usando MVC e Swagger
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure( IApplicationBuilder app, IHostingEnvironment env )
        {
            if ( env.IsDevelopment( ) )
            {
                app.UseDeveloperExceptionPage( );
            }

            app.UseMvc();
            app.SwaggerApplication();
            app.UseMvc( );
        }
    }
}
