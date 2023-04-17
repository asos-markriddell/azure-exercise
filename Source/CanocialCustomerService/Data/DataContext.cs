using Microsoft.EntityFrameworkCore;
using System.Net;
using Data.Entities;

namespace Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<CanonicalCustomer> CanonicalCustomer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CanonicalCustomer>().HasData(
                new CanonicalCustomer
                {
                    CustomerId = 1,
                    FullName = "John Smith",
                    Email = "john.smith@asos.com",
                    CanonicalCustomerId = 1,
                    Country = "N. Ireland",
                    MobileNumber = "02876 651326"
                });
        }
    }
}
