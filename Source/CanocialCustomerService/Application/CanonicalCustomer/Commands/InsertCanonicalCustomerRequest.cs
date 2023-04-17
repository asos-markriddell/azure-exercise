using Domain.Models;
using MediatR;

namespace Application.CanonicalCustomer.Commands
{
    public class InsertCanonicalCustomerRequest : IRequest<InsertCanonicalCustomerResponse>
    {
        public CanonicalCustomerModel CanonicalCustomer { get; set; }

        public InsertCanonicalCustomerRequest(CanonicalCustomerModel canonicalCustomer)
        {
            CanonicalCustomer = canonicalCustomer;
        }
    }
}
