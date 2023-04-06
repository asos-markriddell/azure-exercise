using Domain.Models;

namespace Application.Customers.Queries.GetCustomer
{
    public interface IGetCustomerQuery
    {
        Task<Customer> Execute(int customerId);
    }
}
