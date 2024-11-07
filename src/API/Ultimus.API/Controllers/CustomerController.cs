using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ultimus.Application.Features.Customer.Queries.GetCustomerCountByStateAndAddressType;
using Ultimus.Application.Features.Customer.Queries.GetCustomersList;

namespace Ultimus.API.Controllers
{
    [Route("api/customers")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<CustomersListOutputVM>>> GetAllCustomers()
        {
            var dtos = await _mediator.Send(new GetCustomersListQuery());
            return Ok(dtos);
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<CustomerCountByStateAndAddressTypeOutputVM>>> GeCustomersCountByStateAndAddressType()
        {
            var dtos = await _mediator.Send(new GetCustomerCountByStateAndAddressTypeQuery());
            return Ok(dtos);
        }
    }
}
