using Ultimus.Application.Common.Responses;

namespace Ultimus.Application.Features.Customer.Queries.GetCustomersList
{
    public class GetCustomersListQueryResponse : BaseResponse
    {
        public GetCustomersListQueryResponse() : base()
        {

        }
        public List<CustomersListOutputVM> data { get; set; } = default!;        
    }
}
