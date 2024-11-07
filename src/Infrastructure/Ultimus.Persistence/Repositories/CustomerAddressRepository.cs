using Ultimus.Application.Contracts.Persistence;
using Ultimus.Domain.Entities;

namespace Ultimus.Persistence.Repositories
{
    public class CustomerAddressRepository : BaseRepository<CustomerAddress>, ICustomerAddressRepository
    {
        public CustomerAddressRepository(AdventureWorksDbContext dbContext) : base(dbContext)
        {

        }
    }
}
