using Application.Customers.Queries.GetCustomer;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerDataService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly IGetCustomerQuery _customerQuery;

        public CustomerController(ILogger<CustomerController> logger, IGetCustomerQuery customerQuery)
        {
            _logger = logger;
            this._customerQuery = customerQuery;
        }

        [HttpGet(Name = "GetCustomer")]
        public async Task<Customer> Get(int customerId)
        {
            _logger.LogInformation("Customer Controller : Get By Id {0}", customerId);

            return await _customerQuery.Execute(customerId);
        }
    }
}
