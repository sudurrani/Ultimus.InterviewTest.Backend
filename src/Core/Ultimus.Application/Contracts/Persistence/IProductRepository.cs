using Ultimus.Domain.Entities;

namespace Ultimus.Application.Contracts.Persistence
{
    public interface IProductRepository : IAsyncRepository<Product>
    {
    }
}
