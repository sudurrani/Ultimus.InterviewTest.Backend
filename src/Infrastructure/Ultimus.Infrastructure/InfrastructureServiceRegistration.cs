using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ultimus.Application.Contracts.Infrastructure.Encryption;
using Ultimus.Infrastructure.Encryption;

namespace Ultimus.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {           
            services.AddTransient<IEncryptionService, EncryptionService>();            

            return services;
        }
    }
}
