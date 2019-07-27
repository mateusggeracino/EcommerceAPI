﻿using Ecommerce.Application.AutoMapper;
using Ecommerce.Business;
using Ecommerce.Business.Interfaces;
using Ecommerce.Domain.Models;
using Ecommerce.Repository;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Services;
using Ecommerce.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Application.Extensions
{
    public static class DependencyInjection
    {
        public static void DepencencyInjection(this IServiceCollection services)
        {
            var mapperConfig = AutoMapperConfig.RegisterMappings();
            services.AddSingleton(mapperConfig.CreateMapper());

            DependencyInjectionBusiness(services);
            DependencyInjectionServices(services);
            DependencyInjectionRepository(services);
            services.BuildServiceProvider();
        }

        /// <summary>
        /// Injeção de dependencia services
        /// </summary>
        /// <param name="services"></param>
        public static void DependencyInjectionServices(IServiceCollection services)
        {
            services.AddTransient<IStockServices, StockServices>();
            services.AddTransient<IClientServices, ClientServices>();
            services.AddTransient<IPaymentMethodService, PaymentMethodService>();
            services.AddTransient<IShoppingCartServices, ShoppingCartServices>();
        }

        /// <summary>
        /// Injeção de dependencia Repository
        /// </summary>
        /// <param name="services"></param>
        public static void DependencyInjectionRepository(IServiceCollection services)
        {
            services.AddSingleton<IStockRepository, StockRepository>();
            services.AddSingleton<IPaymentMethodRepository, PaymentMethodRepository>();
            services.AddSingleton<IRepository<Stock>, Repository<Stock>>();
            services.AddSingleton<IShoppingKartsRepository, ShoppingKartsRepository>();
            //services.AddTransient<IClientRepository, ClientRepository>();
        }

        /// <summary>
        /// Injeção de dependencia Business
        /// </summary>
        /// <param name="services"></param>
        public static void DependencyInjectionBusiness(IServiceCollection services)
        {
            services.AddTransient<IStockBusiness, StockBusiness>();
            services.AddTransient<IClientBusiness, ClientBusiness>();
            services.AddTransient<IShoppingCartsBusiness, ShoppingKartsBusiness>();
            services.AddTransient<IStockBusiness, StockBusiness>();
            services.AddTransient<IClientBusiness, ClientBusiness>();
            services.AddTransient<IPaymentMethodBusiness, PaymentMethodBusiness>();
        }

    }
}