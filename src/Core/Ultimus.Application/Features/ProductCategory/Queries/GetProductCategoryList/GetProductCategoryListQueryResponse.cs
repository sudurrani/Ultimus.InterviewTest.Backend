using Ultimus.Application.Common.Responses;

namespace Ultimus.Application.Features.ProductCategory.Queries.GetProductCategoryList
{
    public class GetProductCategoryListQueryResponse : BaseResponse
    {
        public GetProductCategoryListQueryResponse() : base()
        {

        }
        public List<ProductCategoryListOutputVM> data { get; set; } = default!;
    }
}
