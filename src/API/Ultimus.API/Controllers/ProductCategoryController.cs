using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ultimus.Application.Features.Product.Queries.GetProductsList;
using Ultimus.Application.Features.ProductCategory.Queries.GetProductCategoryList;

namespace Ultimus.API.Controllers
{
    [Route("api/product-categories")]
    [ApiController]
    [Authorize]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<ProductsListOutputVM>>> GetAllProductCategories()
        {
            var dtos = await _mediator.Send(new GetProductCategoryListQuery());
            return Ok(dtos);
        }
    }
}
