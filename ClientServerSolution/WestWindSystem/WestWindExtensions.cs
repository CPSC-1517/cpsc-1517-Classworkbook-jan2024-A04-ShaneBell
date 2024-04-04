using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WestWindSystem.DAL;
using WestWindSystem.BLL;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace WestWindSystem
{
    public static class WestWindExtensions
    {

        public static void WWExtensions(
            this IServiceCollection services, Action<DbContextOptionsBuilder> options)
        {
            //Register the context
            services.AddDbContext<WestWindContext>(options);

            //We need to AddTransient for each services class in the BLL
            services.AddTransient<CustomerServices>((ServiceProvider) =>
            {
                var context = ServiceProvider.GetService<WestWindContext>();
                return new CustomerServices(context);
            });

            services.AddTransient<RegionServices>((ServiceProvider) =>
            {
                var context = ServiceProvider.GetService<WestWindContext>();
                return new RegionServices(context);
            });

            services.AddTransient<OrderServices>((ServiceProvider) =>
            {
                var context = ServiceProvider.GetService<WestWindContext>();
                return new OrderServices(context);
            });

            services.AddTransient<ProductServices>((ServiceProvider) =>
            {
                var context = ServiceProvider.GetService<WestWindContext>();
                return new ProductServices(context);
            });

            services.AddTransient<CategoryServices>((ServiceProvider) =>
            {
                var context = ServiceProvider.GetService<WestWindContext>();
                return new CategoryServices(context);
            });

        }


    }
}
