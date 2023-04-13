using Application.Customers.Queries.GetCustomer;
using Domain.Models.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerDataService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly IMediator _mediator;

        public CustomerController(ILogger<CustomerController> logger, IMediator mediator)
        {
            _logger = logger;
            this._mediator = mediator;
        }

        [HttpGet(Name = "GetCustomer")]
        public async Task<ActionResult> GetCustomer(int customerId)
        {
            _logger.LogInformation("Customer Controller : Get By Id {0}", customerId);

            GetCustomerByIdResponse response = await _mediator.Send(new GetCustomerByIdRequest() { CustomerId = customerId});

            if (response.Customer == null) return NotFound();

            return Ok(response);
        }
    }
}
