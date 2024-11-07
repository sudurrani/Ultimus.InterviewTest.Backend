using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ultimus.Application.Features.Product.Queries.GetProductsList;
using Ultimus.Application.Features.SaleOrder.Queries.GetSaleOrderDetailList;

namespace Ultimus.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<ProductsListOutputVM>>> GetAllProducts()
        {
            var dtos = await _mediator.Send(new GetProductsListQuery());
            return Ok(dtos);
        }
        [HttpGet("most-sold")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<ProductsListOutputVM>>> GetTopTenMostSoldProduct()
        {
            var dtos = await _mediator.Send(new GetSaleOrderDetailListQuery());
            return Ok(dtos);
        }
    }
}
