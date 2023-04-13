namespace Application.CanonicalCustomer.Commands
{
    public class InsertCanonicalCustomerResponse
    {
        public int CanonicalCustomerId { get; set; }

        public InsertCanonicalCustomerResponse(int canonicalCustomerId)
        {
            CanonicalCustomerId = canonicalCustomerId;
        }
    }
}
