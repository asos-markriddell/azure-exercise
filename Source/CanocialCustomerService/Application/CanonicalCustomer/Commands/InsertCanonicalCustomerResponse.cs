namespace Application.CanonicalCustomer.Commands
{
    public class InsertCanonicalCustomerResponse
    {
        public Domain.Models.CanonicalCustomerModel CanonicalCustomer;
        
        public InsertCanonicalCustomerResponse(Domain.Models.CanonicalCustomerModel canonicalCustomer)
        {
            CanonicalCustomer = canonicalCustomer;
        }
    }
}
