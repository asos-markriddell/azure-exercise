using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class CanonicalCustomer
    {
        [Key]
        public int CanonicalCustomerId { get; set; }
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Country { get; set; }
    }
}
