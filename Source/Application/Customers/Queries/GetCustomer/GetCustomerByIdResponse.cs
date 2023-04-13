using Domain.Models.Dto;
using MediatR;

namespace Application.Customers.Queries.GetCustomer
{
    public class GetCustomerByIdResponse
    {
        public CustomerDto Customer { get; set; }
    }
}
