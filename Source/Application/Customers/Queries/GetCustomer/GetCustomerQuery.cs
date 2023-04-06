using Application.Contracts;
using Domain.Models;

namespace Application.Customers.Queries.GetCustomer
{
    public class GetCustomerQuery : IGetCustomerQuery
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerQuery(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> Execute(int customerId)
        {
            return _customerRepository.GetAsync(customerId).Result;
        }
    }
}