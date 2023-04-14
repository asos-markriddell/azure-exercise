using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CanonicalCustomerApi.Controllers
{
    public class CanonicalCustomerController : Controller
    {
        [HttpGet(Name="GetCanonicalCustomer")]
        public async Task<ActionResult> GetCanonicalCustomer(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet(Name = "InsertCanonicalCustomer")]
        public async Task<ActionResult> InsertCanonicalCustomer(CanonicalCustomerDto customer)
        {
            throw new NotImplementedException();
        }

        [HttpGet(Name = "UpdateCanonicalCustomer")]
        public async Task<ActionResult> UpdateCanonicalCustomer(CanonicalCustomerDto customer)
        {
            throw new NotImplementedException();
        }
        
        [HttpGet(Name = "DeleteCanonicalCustomer")]
        public async Task<ActionResult> DeleteCanonicalCustomer(int id)
        {
            throw new NotImplementedException();
        }
        
    }
}
