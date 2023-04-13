using Domain.Models.Dto;
using MediatR;

namespace Application.Customers.Queries.GetCustomer
{
    public class GetCustomerByIdResponse
    {
        public GetCustomerByIdResponse(CustomerDto customer)
        {
            Customer = customer;
        }

        public CustomerDto Customer { get; set; }
    }
}
