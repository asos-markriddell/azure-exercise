using Domain.Models;
using MediatR;

namespace Application.CanonicalCustomer.Commands
{
    public class UpdateCanonicalCustomerRequest : IRequest<UpdateCanonicalCustomerResponse>
    {
        public CanonicalCustomerDto CanonicalCustomer { get; set; }

        public UpdateCanonicalCustomerRequest(CanonicalCustomerDto canonicalCustomer)
        {
            CanonicalCustomer = canonicalCustomer;
        }
    }
}
