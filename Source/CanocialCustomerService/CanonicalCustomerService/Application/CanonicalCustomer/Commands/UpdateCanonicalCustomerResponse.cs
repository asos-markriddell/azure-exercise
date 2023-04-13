namespace Application.CanonicalCustomer.Commands
{
    public class UpdateCanonicalCustomerResponse
    {
        public int CanonicalCustomerId { get; set; }

        public UpdateCanonicalCustomerResponse(int canonicalCustomerId)
        {
            CanonicalCustomerId = canonicalCustomerId;
        }
    }
}
