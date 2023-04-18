using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerId = 1, Forename = "John", Surname = "Smith", Email = "john.smith@asos.com",
                    DateOfBirth = DateTime.Parse("16/02/2008 12:15:12")
                });

            modelBuilder.Entity<Address>().HasData(new Address
            {
                AddressId = 1,
                AddressLine1 = "ASOS",
                AddressLine2 = "Third Floor",
                AddressLine3 = "Custom House",
                City = "Belfast",
                Country = "N. Ireland",
                County = "Co. Antrim",
                CustomerId = 1,
                PostalCode = "BT12 7LZ"
            });

            modelBuilder.Entity<Contact>().HasData(new Contact
            {
                CustomerId = 1,
                ContactId = 1,
                HomeNumber = "02879 635241",
                MobileNumber = "07725 339698"
            });
        }
    }
}
