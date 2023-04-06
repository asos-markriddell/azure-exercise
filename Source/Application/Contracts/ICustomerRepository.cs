using Domain.Models;

namespace Application.Contracts
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetAsync(int? id);
    }
}
