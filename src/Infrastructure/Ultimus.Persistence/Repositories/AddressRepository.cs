using Ultimus.Application.Contracts.Persistence;
using Ultimus.Domain.Entities;

namespace Ultimus.Persistence.Repositories
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(AdventureWorksDbContext dbContext) : base(dbContext)
        {

        }
    }
}
