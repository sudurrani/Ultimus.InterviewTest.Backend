using Ultimus.Application.Contracts.Persistence;
using Ultimus.Domain.Entities;

namespace Ultimus.Persistence.Repositories
{
    public class ProductCategoryRepository : BaseRepository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(AdventureWorksDbContext dbContext) : base(dbContext)
        {

        }
    }
}
