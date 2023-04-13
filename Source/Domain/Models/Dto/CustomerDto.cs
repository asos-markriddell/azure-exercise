namespace Domain.Models.Dto
{
    public class CustomerDto
    {
        public int CustomerId { get; set; } 
        public string Fullname { get; set; }
        public string Email { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
        public IEnumerable<Contact> Contacts { get; set; }
    }
}
