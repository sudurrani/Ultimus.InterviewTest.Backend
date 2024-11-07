using AutoMapper;
using MediatR;
using Ultimus.Application.Contracts.Persistence;
using Ultimus.Domain.Entities;

namespace Ultimus.Application.Features.ProductCategory.Queries.GetProductCategoryList
{
    public class GetProductCategoryListQueryHandler : IRequestHandler<GetProductCategoryListQuery, GetProductCategoryListQueryResponse>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;
        public GetProductCategoryListQueryHandler(IMapper mapper, IProductCategoryRepository productCategoryRepository)
        {
            _mapper = mapper;
            _productCategoryRepository = productCategoryRepository;
        }
        public async Task<GetProductCategoryListQueryResponse> Handle(GetProductCategoryListQuery request,
            CancellationToken cancellationToken)
        {
            var getProductCategoryListQueryResponse = new GetProductCategoryListQueryResponse();

            var allProductCategory = await _productCategoryRepository.GetAllAsync();

            if (allProductCategory.Count() <= 0)
                getProductCategoryListQueryResponse.Message = $"No, {nameof(ProductCategory)} found";
            else
                getProductCategoryListQueryResponse.Message = $"{allProductCategory.Count()} {nameof(ProductCategory)} found";

            getProductCategoryListQueryResponse.data = _mapper.Map<List<ProductCategoryListOutputVM>>(allProductCategory);
            return getProductCategoryListQueryResponse;
        }
    }
}
