using Domain.Models;

namespace Application.CanonicalCustomer.Queries
{
    public class GetCanonicalCustomerByIdResponse
    {
        public CanonicalCustomerModel CanonicalCustomer { get; set; }

        public GetCanonicalCustomerByIdResponse(CanonicalCustomerModel canonicalCustomer)
        {
            CanonicalCustomer = canonicalCustomer;
        } 
    }
}
