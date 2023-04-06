using Application.Contracts;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _dbContext;

        public CustomerRepository(DataContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<Customer?> GetAsync(int? id)
        {
            if (id == null) throw new ArgumentNullException("Error: A valid id Parameter is required");

            return await _dbContext.FindAsync<Customer>(id);
        }
    }
}
