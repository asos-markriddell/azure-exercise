using Domain.Models;

namespace Application.Customers.Queries.GetCustomer
{
    public class GetCustomerByIdResponse
    {
        public GetCustomerByIdResponse(CustomerModel customer)
        {
            Customer = customer;
        }

        public CustomerModel Customer { get; set; }
    }
}
