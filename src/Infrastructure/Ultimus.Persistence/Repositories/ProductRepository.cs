using Ultimus.Application.Contracts.Persistence;
using Ultimus.Domain.Entities;

namespace Ultimus.Persistence.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(AdventureWorksDbContext dbContext) : base(dbContext)
        {

        }
    }
}
