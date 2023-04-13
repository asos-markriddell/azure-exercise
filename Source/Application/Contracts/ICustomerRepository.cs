using Domain.Models.Dto;

namespace Application.Contracts
{
    public interface ICustomerRepository
    {
        CustomerDto GetCustomerById(int id);
    }
}
