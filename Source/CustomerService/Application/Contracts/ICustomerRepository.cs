using Domain.Models;

namespace Application.Contracts
{
    public interface ICustomerRepository
    {
        Task<CustomerModel> GetCustomerById(int id);
    }
}
