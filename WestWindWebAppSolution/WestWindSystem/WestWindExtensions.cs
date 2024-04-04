using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using WestWindSystem.DAL;
using WestWindSystem.BLL;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
#endregion

namespace WestWindSystem
{
    public static class WestWindExtensions
    {
        public static void WWExtensions(
            this IServiceCollection services, Action<DbContextOptionsBuilder> options)
        {
            //IServiceCollection
            //We need to register all the services that will be available by anything using this library
            

            //Register the context service
            services.AddDbContext<WestWindContext>(options);

            //Regiser services
            //Each service class must be registered for use by the outside world
            //Each service class will have it's own AddTransient<T>()

            services.AddTransient<CustomerServices>((ServiceProvider) =>
            {
                //Get the Context class that was resitered above
                var context = ServiceProvider.GetService<WestWindContext>();
                //Create an instance of the serivce class
                //Supply the context reference to the service class constructor
                return new CustomerServices(context);
            });

            services.AddTransient<RegionServices>((ServiceProvider) =>
            {
                //Get the Context class that was resitered above
                var context = ServiceProvider.GetService<WestWindContext>();
                //Create an instance of the serivce class
                //Supply the context reference to the service class constructor
                return new RegionServices(context);
            });

            services.AddTransient<OrderServices>((ServiceProvider) =>
            {
                //Get the Context class that was resitered above
                var context = ServiceProvider.GetService<WestWindContext>();
                //Create an instance of the serivce class
                //Supply the context reference to the service class constructor
                return new OrderServices(context);
            });


            services.AddTransient<CategoryServices>((ServiceProvider) =>
            {
                //Get the Context class that was resitered above
                var context = ServiceProvider.GetService<WestWindContext>();
                //Create an instance of the serivce class
                //Supply the context reference to the service class constructor
                return new CategoryServices(context);
            });

            services.AddTransient<ProductServices>((ServiceProvider) =>
            {
                //Get the Context class that was resitered above
                var context = ServiceProvider.GetService<WestWindContext>();
                //Create an instance of the serivce class
                //Supply the context reference to the service class constructor
                return new ProductServices(context);
            });

            services.AddTransient<SupplierServices>((ServiceProvider) =>
            {
                //Get the Context class that was resitered above
                var context = ServiceProvider.GetService<WestWindContext>();
                //Create an instance of the serivce class
                //Supply the context reference to the service class constructor
                return new SupplierServices(context);
            });


        }       
    }
}
