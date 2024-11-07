using Ultimus.Application.Common.Responses;

namespace Ultimus.Application.Features.Address.Queries.GetAddressesList
{
    public class GetAddressesListQueryResponse : BaseResponse        
    {
        public GetAddressesListQueryResponse() : base()
        {
            
        }
        public List<AddressesListOutputVM> data { get; set; } = default!;
    }
}
