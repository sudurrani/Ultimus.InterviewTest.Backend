using Ultimus.Application.Common.Responses;
using Ultimus.Application.Features.ProductCategory.Queries.GetProductCategoryList;

namespace Ultimus.Application.Features.SaleOrder.Queries.GetSaleOrderDetailList
{
    public class GetSaleOrderDetailListQueryResponse : BaseResponse
    {
        public GetSaleOrderDetailListQueryResponse() : base()
        {
            
        }
        public List<SaleOrderDetailListVM> data { get; set; } = default!;        
    }
}
