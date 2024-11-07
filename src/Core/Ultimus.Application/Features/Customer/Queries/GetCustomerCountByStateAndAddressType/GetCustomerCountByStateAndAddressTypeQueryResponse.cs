using Ultimus.Application.Common.Responses;

namespace Ultimus.Application.Features.Customer.Queries.GetCustomerCountByStateAndAddressType
{
    public class GetCustomerCountByStateAndAddressTypeQueryResponse : BaseResponse
    {
        public GetCustomerCountByStateAndAddressTypeQueryResponse() : base()
        {

        }
        public List<CustomerCountByStateAndAddressTypeOutputVM> data { get; set; } = default!;
    }
}
