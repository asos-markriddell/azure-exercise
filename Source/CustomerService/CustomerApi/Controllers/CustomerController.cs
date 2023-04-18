using Application.Customers.Queries.GetCustomer;
using CustomerDataService.Constants;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerDataService.Controllers
{
    [Route($"{Routes.RoutePrefix}[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        #region "Properties"

        private readonly ILogger<CustomerController> _logger;
        private readonly IMediator _mediator;

        #endregion

        #region "Constructors"

        public CustomerController(ILogger<CustomerController> logger, IMediator mediator)
        {
            _logger = logger;
            this._mediator = mediator;
        }

        #endregion

        #region "Endpoints"

        [HttpGet("{customerId}", Name = "GetCustomer")]
        public async Task<ActionResult> GetCustomer([FromRoute] int customerId)
        {
            _logger.LogInformation("Customer Controller : Get By Id {0}", customerId);

            var query = new GetCustomerByIdRequest(customerId);

            GetCustomerByIdResponse response = await _mediator.Send(query);

            if (response.Customer is null) return NotFound();

            return Ok(response.Customer);
        }

        #endregion
    }
}
