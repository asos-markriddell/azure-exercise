using Data.Entities;

namespace Domain.Models
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
        public IEnumerable<Contact> Contacts { get; set; }
    }
}
