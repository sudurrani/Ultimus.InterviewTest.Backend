using AutoMapper;
using MediatR;
using Ultimus.Application.Contracts.Persistence;
using Ultimus.Domain.Entities;

namespace Ultimus.Application.Features.SaleOrder.Queries.GetSaleOrderDetailList
{
    public class GetSaleOrderDetailListQueryHandler : IRequestHandler<GetSaleOrderDetailListQuery, GetSaleOrderDetailListQueryResponse>
    {
        private readonly ISaleOrderRepository _saleOrderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;
        public GetSaleOrderDetailListQueryHandler(IMapper mapper, ISaleOrderRepository saleOrderRepository, IProductRepository productRepository, IProductCategoryRepository productCategoryRepository)
        {
            _mapper = mapper;
            _saleOrderRepository = saleOrderRepository;
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
        }
        public async Task<GetSaleOrderDetailListQueryResponse> Handle(GetSaleOrderDetailListQuery request, CancellationToken cancellationToken)
        {
            var getSaleOrderDetailListQueryResponse = new GetSaleOrderDetailListQueryResponse();

            var saleOrdersDetail = await _saleOrderRepository.GetAllAsync();
            var products = await _productRepository.GetAllAsync();
            var productCategories = await _productCategoryRepository.GetAllAsync();


            var topTenSoldPrducts = saleOrdersDetail
                                    .Join(products, sod => sod.ProductId, p => p.ProductId, (sod, p) => new { sod, p })
                                    .Join(productCategories, temp => temp.p.ProductCategoryId, pc => pc.ProductCategoryId, (temp, pc) => new { temp.sod, temp.p, pc })
                                    .OrderByDescending(x => x.sod.LineTotal)
                                    .Take(10)
                                    .Select(x => new SaleOrderDetailListVM
                                    {
                                        Category = x.pc.Name,
                                        Amount = x.sod.LineTotal
                                    })
                                    .ToList();



            if (topTenSoldPrducts.Count() <= 0)
                getSaleOrderDetailListQueryResponse.Message = $"No, {nameof(SalesOrderDetail)} found";
            else
                getSaleOrderDetailListQueryResponse.Message = $"{topTenSoldPrducts.Count()} {nameof(SalesOrderDetail)} found";

            getSaleOrderDetailListQueryResponse.data = topTenSoldPrducts;
            return getSaleOrderDetailListQueryResponse;
        }
    }
}
