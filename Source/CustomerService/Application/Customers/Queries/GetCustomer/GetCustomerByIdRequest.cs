using MediatR;

namespace Application.Customers.Queries.GetCustomer
{
    public class GetCustomerByIdRequest : IRequest<GetCustomerByIdResponse>
    {
        public GetCustomerByIdRequest(int customerId)
        {
            CustomerId = customerId;
        }

        public int CustomerId { get; set; }
    }
}