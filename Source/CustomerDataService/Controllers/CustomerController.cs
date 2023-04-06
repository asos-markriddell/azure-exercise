using CustomerDataService.Repository;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerDataService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ILogger<CustomerController> logger, ICustomerRepository customerRepository)
        {
            _logger = logger;
            this._customerRepository = customerRepository;
        }

        [HttpGet(Name = "GetCustomer")]
        public async Task<Customer> Get(int customerId)
        {
            return await _customerRepository.GetAsync(customerId);
        }
    }
}
