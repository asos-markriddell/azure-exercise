namespace Domain.Models.Dto
{
    public class CustomerDto
    {
        public int CustomerId { get; set; } 
        public string Fullname { get; set; }
        public string Email { get; set; }
        public int MobileNumber { get; set; }
        public string Country { get; set; }
        //public Address Address { get; set; }
        //public Contact Contact { get; set; }

    }
}
