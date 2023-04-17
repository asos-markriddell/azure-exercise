using Domain.Models;
using MediatR;

namespace Application.CanonicalCustomer.Commands
{
    public class InsertCanonicalCustomerRequest : IRequest<InsertCanonicalCustomerResponse>
    {
        public CanonicalCustomerDto CanonicalCustomer { get; set; }

        public InsertCanonicalCustomerRequest(CanonicalCustomerDto canonicalCustomer)
        {
            CanonicalCustomer = canonicalCustomer;
        }
    }
}
