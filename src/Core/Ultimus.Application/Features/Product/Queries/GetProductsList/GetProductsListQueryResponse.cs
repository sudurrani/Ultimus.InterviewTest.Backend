using Ultimus.Application.Common.Responses;
using Ultimus.Application.Features.Customer.Queries.GetCustomersList;

namespace Ultimus.Application.Features.Product.Queries.GetProductsList
{
    public class GetProductsListQueryResponse : BaseResponse
    {
        public GetProductsListQueryResponse() : base()
        {

        }
        public List<ProductsListOutputVM> data { get; set; } = default!;
    }
}
