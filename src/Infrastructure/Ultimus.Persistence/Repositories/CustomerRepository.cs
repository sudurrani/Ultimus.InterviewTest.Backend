using Ultimus.Application.Contracts.Persistence;
using Ultimus.Domain.Entities;

namespace Ultimus.Persistence.Repositories
{   
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AdventureWorksDbContext dbContext) : base(dbContext)
        {

        }
    }
}
