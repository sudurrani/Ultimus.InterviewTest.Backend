using Ultimus.Application.Contracts.Persistence;
using Ultimus.Domain.Entities;

namespace Ultimus.Persistence.Repositories
{
    public class SaleOrderRepository : BaseRepository<SalesOrderDetail>, ISaleOrderRepository
    {
        public SaleOrderRepository(AdventureWorksDbContext dbContext) : base(dbContext)
        {

        }
    }
}
