using MediatR;

namespace Application.CanonicalCustomer.Commands
{
    public class DeleteCanonicalCustomerRequest : IRequest<DeleteCanonicalCustomerResponse>
    { 
        public int CanonicalCustomerId { get; set; }

        public DeleteCanonicalCustomerRequest(int id)
        {
            CanonicalCustomerId = id;
        }
    }
}
