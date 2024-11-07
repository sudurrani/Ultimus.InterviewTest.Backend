using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ultimus.Application.Contracts.Persistence;
using Ultimus.Persistence.Repositories;

namespace Ultimus.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AdventureWorksDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AdventureWorksLT2022DbConnection")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<ICustomerAddressRepository, CustomerAddressRepository>();

            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            
            services.AddScoped<IAddressRepository, AddressRepository>();

            services.AddScoped<ISaleOrderRepository, SaleOrderRepository>();


            
            


            return services;
        }
    }
}
