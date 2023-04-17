using Domain.Models;

namespace Application.Contracts
{
    public interface ICanonicalCustomerRepository
    {
        Task<CanonicalCustomerModel> GetCanonicalCustomer(int id);
        CanonicalCustomerModel InsertCanonicalCustomer(CanonicalCustomerModel canonicalCustomer);
        CanonicalCustomerModel UpdateCanonicalCustomer(CanonicalCustomerModel canonicalCustomer);
        void DeleteCanonicalCustomer(int id);
    }
}
