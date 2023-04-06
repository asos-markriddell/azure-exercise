using CustomerDataService.Data;
using Domain.Models;

namespace CustomerDataService.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _dbContext;

        public CustomerRepository(DataContext context) 
        {
            _dbContext = context;
        }

        public async Task<Customer?> GetAsync(int? id)
        {
            if (id is null)
            {
                return null; // Throw Argument null exception
            }

            return await this._dbContext.Set<Customer>().FindAsync(id);
        }
    }
}
