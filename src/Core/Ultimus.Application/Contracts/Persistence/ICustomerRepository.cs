using Ultimus.Domain.Entities;

namespace Ultimus.Application.Contracts.Persistence
{
    public interface ICustomerRepository : IAsyncRepository<Customer>
    {
    }
}
