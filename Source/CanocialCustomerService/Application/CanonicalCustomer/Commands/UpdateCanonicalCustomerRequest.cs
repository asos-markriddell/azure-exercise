using Domain.Models;
using MediatR;

namespace Application.CanonicalCustomer.Commands
{
    public class UpdateCanonicalCustomerRequest : IRequest<UpdateCanonicalCustomerResponse>
    {
        public CanonicalCustomerModel CanonicalCustomer { get; set; }

        public UpdateCanonicalCustomerRequest(CanonicalCustomerModel canonicalCustomer)
        {
            CanonicalCustomer = canonicalCustomer;
        }
    }
}
