<<<<<<< HEAD
﻿using Ecommerce.Application.AutoMapper;
using Ecommerce.Business;
using Ecommerce.Business.Interfaces;
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Business;
>>>>>>> f1b0fad395b9ff4383ba549e1712f54cb2399b95
using Ecommerce.Domain.Models;
using Ecommerce.Repository;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Services;
<<<<<<< HEAD
using Ecommerce.Services.Interfaces;
=======
>>>>>>> f1b0fad395b9ff4383ba549e1712f54cb2399b95
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
<<<<<<< HEAD
            DependencyInjection(services);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void DependencyInjection(IServiceCollection services)
        {
            var mapper = AutoMapperConfig.RegisterMappings();
            services.AddSingleton(mapper);
            DependencyInjectionBusiness(services);
            DependencyInjectionServices(services);
            DependencyInjectionRepository(services);
        }

        public void DependencyInjectionServices(IServiceCollection services)
        {
            services.AddTransient<IStockServices, StockServices>();
        }

        public void DependencyInjectionRepository(IServiceCollection services)
        {
            services.AddSingleton<IRepository<Stock>, Repository<Stock>>();
            services.AddTransient<IStockRepository, StockRepository>();
        }

        public void DependencyInjectionBusiness(IServiceCollection services)
        {
            services.AddTransient<IStockBusiness, StockBusiness>();
        }

=======
            ClientDependencyInjection(services);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void ClientDependencyInjection(IServiceCollection services)
        {
            services.AddSingleton<IRepository<Client>, Repository<Client>>();
            services.AddTransient<ClientBusiness>();
            services.AddTransient<Client>();
            services.AddTransient<ClientServices>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
>>>>>>> f1b0fad395b9ff4383ba549e1712f54cb2399b95
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
