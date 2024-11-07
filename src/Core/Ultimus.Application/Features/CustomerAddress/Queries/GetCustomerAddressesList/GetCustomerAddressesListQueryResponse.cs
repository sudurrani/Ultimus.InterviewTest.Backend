using Ultimus.Application.Common.Responses;

namespace Ultimus.Application.Features.CustomerAddress.Queries.GetCustomerAddressesList
{
    public class GetCustomerAddressesListQueryResponse : BaseResponse
    {
        public GetCustomerAddressesListQueryResponse() : base()
        {

        }
        //public List<CustomerAddressesListOutputVM> data { get; set; } = default!;
        public List<string> data { get; set; }
    }
}
