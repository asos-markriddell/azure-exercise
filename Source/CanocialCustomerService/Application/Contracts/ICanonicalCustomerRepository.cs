using Domain.Models;

namespace Application.Contracts
{
    public interface ICanonicalCustomerRepository
    {
        Task<CanonicalCustomerDto> GetCanonicalCustomer(int id);
        CanonicalCustomerDto InsertCanonicalCustomer(CanonicalCustomerDto canonicalCustomer);
        CanonicalCustomerDto UpdateCanonicalCustomer(CanonicalCustomerDto canonicalCustomer);
        void DeleteCanonicalCustomer(int id);
    }
}
