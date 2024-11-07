using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ultimus.Application.Features.CustomerAddress.Queries.GetCustomerAddressesList;

namespace Ultimus.API.Controllers
{
    [Route("api/customer-addresses")]
    [ApiController]
    [Authorize]
    public class CustomerAddressController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerAddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<CustomerAddressesListOutputVM>>> GetAllCustomerAddress()
        {
            var dtos = await _mediator.Send(new GetCustomerAddressesListQuery());
            return Ok(dtos);
        }
    }
} 
