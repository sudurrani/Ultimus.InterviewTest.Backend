using Ultimus.Domain.Entities;

namespace Ultimus.Application.Contracts.Persistence
{
    public interface ICustomerAddressRepository : IAsyncRepository<CustomerAddress>
    {
    }
}
