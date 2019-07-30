using Ecommerce.Application.AutoMapper;
using Ecommerce.Business;
using Ecommerce.Business.Interfaces;
using Ecommerce.Repository;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Services;
using Ecommerce.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Application.Extensions
{
    public static class DependencyInjection
    {
        public static void DepencencyInjection( this IServiceCollection services )
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
        public static void DependencyInjectionServices( IServiceCollection services )
        {
            services.AddTransient<IStockServices, StockServices>( );
            services.AddTransient<IClientServices, ClientServices>( );
            services.AddTransient<IPaymentMethodService, PaymentMethodService>( );
            services.AddTransient<IShoppingCartServices, ShoppingCartServices>( );
            services.AddTransient<IProductServices, ProductServices>( );
            services.AddTransient<IPriceServices, PriceServices>( );
        }

        /// <summary>
        /// Injeção de dependencia Repository
        /// </summary>
        /// <param name="services"></param>
        public static void DependencyInjectionRepository( IServiceCollection services )
        {
            services.AddSingleton<IStockRepository, StockRepository>( );
            services.AddSingleton<IStoreRepository, StoreRepository>( );
            services.AddSingleton<IPaymentMethodRepository, PaymentMethodRepository>( );
            services.AddSingleton<IShoppingCartsRepository, ShoppingCartsRepository>( );
            services.AddSingleton<IOrderRepository, OrderRepository>( );
            services.AddSingleton<IClientRepository, ClientRepository>( );
            services.AddSingleton<IProductRepository, ProductRepository>( );
            services.AddSingleton<IPaymentAuthorizeRepository, PaymentAuthorizeRepository>();
            services.AddSingleton<IPriceRepository, PriceRepository>();
        }

        /// <summary>
        /// Injeção de dependencia Business
        /// </summary>
        /// <param name="services"></param>
        public static void DependencyInjectionBusiness( IServiceCollection services )
        {
            services.AddTransient<IStockBusiness, StockBusiness>( );
            services.AddTransient<IClientBusiness, ClientBusiness>( );
            services.AddTransient<IShoppingCartsBusiness, ShoppingCartsBusiness>( );
            services.AddTransient<IClientBusiness, ClientBusiness>( );
            services.AddTransient<IPaymentMethodBusiness, PaymentMethodBusiness>( );
            services.AddTransient<IProductBusiness, ProductBusiness>( );
            services.AddTransient<IPaymentAuthorizeBusiness, PaymentAuthorizeBusiness>( );
            services.AddTransient<IPriceBusiness, PriceBusiness>( );
        }

    }
}