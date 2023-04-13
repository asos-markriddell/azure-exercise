using MediatR;

namespace Application.Customers.Queries.GetCustomer
{
    public record GetCustomerByIdRequest : IRequest<GetCustomerByIdResponse>
    {
        public int CustomerId { get; set; }
    }
}