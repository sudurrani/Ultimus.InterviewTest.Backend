using AutoMapper;
using MediatR;
using Ultimus.Application.Contracts.Persistence;

namespace Ultimus.Application.Features.Product.Queries.GetProductsList
{
    public class GetProductsListQueryHandler : IRequestHandler<GetProductsListQuery, GetProductsListQueryResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetProductsListQueryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<GetProductsListQueryResponse> Handle(GetProductsListQuery request,
            CancellationToken cancellationToken)
        {
            var getProductsListQueryResponse = new GetProductsListQueryResponse();

            var allProducts = await _productRepository.GetAllAsync(row => row.ProductCategory!);

            if (allProducts.Count() <= 0)
                getProductsListQueryResponse.Message = $"No, {nameof(Product)} found";
            else
                getProductsListQueryResponse.Message = $"{allProducts.Count()} {nameof(Product)} found";

            getProductsListQueryResponse.data = allProducts.Select(item => new ProductsListOutputVM
            {
               Name = item.Name,
                ProductNumber = item.ProductNumber,
                ListPrice = item.ListPrice,                
                SellEndDate = item.SellEndDate,
                Category = item.ProductCategory!.Name,
                ProductCategoryId = item.ProductCategoryId,
            }).ToList();
            
            return getProductsListQueryResponse;
        }
    }
}
