namespace Application.CanonicalCustomer.Commands
{
    public class DeleteCanonicalCustomerResponse
    {
        public int CanonicalCustomerId { get; set; }

        public DeleteCanonicalCustomerResponse(int canonicalCustomerId)
        {
            CanonicalCustomerId = canonicalCustomerId;
        }
    }
}
