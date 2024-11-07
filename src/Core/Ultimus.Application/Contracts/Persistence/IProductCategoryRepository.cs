using Ultimus.Domain.Entities;

namespace Ultimus.Application.Contracts.Persistence
{
    public interface IProductCategoryRepository : IAsyncRepository<ProductCategory>
    {
    }
}
