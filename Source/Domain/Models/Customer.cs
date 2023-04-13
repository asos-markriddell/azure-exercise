using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Contact> Contacts { get; set; }
    }
}
