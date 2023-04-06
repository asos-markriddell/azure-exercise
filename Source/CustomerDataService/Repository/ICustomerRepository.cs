using Domain.Models;

namespace CustomerDataService.Repository
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetAsync(int? id);
    }
}
