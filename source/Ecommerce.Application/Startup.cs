using Ecommerce.Application.AutoMapper;
using Ecommerce.Business;
using Ecommerce.Business.Interfaces;
using Ecommerce.Domain.Models;
using Ecommerce.Repository;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Services;
using Ecommerce.Services.Interfaces;
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
