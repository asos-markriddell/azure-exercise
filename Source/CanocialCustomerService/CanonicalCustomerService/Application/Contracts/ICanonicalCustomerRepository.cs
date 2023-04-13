using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.Contracts
{
    public interface ICanonicalCustomerRepository
    {
        CanonicalCustomerDto GetCanonicalCustomer(int id);
        void InsertCanonicalCustomer(CanonicalCustomerDto canonicalCustomer);
        void UpdateCanonicalCustomer(CanonicalCustomerDto canonicalCustomer);
    }
}
