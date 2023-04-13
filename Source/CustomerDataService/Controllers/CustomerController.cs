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
        private readonly ISender _sender;

        public CustomerController(ILogger<CustomerController> logger, ISender sender)
        {
            _logger = logger;
            this._sender = sender;
        }

        [HttpGet(Name = "GetCustomer")]
        public async Task<ActionResult> GetCustomer(int customerId)
        {
            _logger.LogInformation("Customer Controller : Get By Id {0}", customerId);

            var customer = await _sender.Send(new GetCustomerByIdRequest() { CustomerId = customerId});

            return Ok(customer);
        }
    }
}
