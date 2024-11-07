using Ultimus.Domain.Entities;

namespace Ultimus.Application.Contracts.Persistence
{
    public interface ISaleOrderRepository : IAsyncRepository<SalesOrderDetail>
    {
    }
}
