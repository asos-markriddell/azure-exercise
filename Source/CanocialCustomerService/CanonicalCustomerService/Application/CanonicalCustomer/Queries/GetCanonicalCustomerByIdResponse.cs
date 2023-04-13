using Domain.Models;

namespace Application.CanonicalCustomer.Queries
{
    public class GetCanonicalCustomerByIdResponse
    {
        public CanonicalCustomerDto CanonicalCustomer { get; set; }

        public GetCanonicalCustomerByIdResponse(CanonicalCustomerDto canonicalCustomer)
        {
            CanonicalCustomer = canonicalCustomer;
        } 
    }
}
