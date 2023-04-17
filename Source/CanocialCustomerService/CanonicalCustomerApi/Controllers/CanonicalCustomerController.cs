using Application.CanonicalCustomer.Commands;
using Application.CanonicalCustomer.Queries;
using CanonicalCustomerApi.Constants;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CanonicalCustomerApi.Controllers
{
    [Route($"{Routes.RoutePrefix}[controller]")]
    [ApiController]
    public class CanonicalCustomerController : Controller
    {
        #region "Properties"

        private readonly ILogger<CanonicalCustomerController> _logger;
        private readonly IMediator _mediator;

        #endregion

        #region "Constructors"

        public CanonicalCustomerController(ILogger<CanonicalCustomerController> logger, IMediator mediator)
        {
            this._logger = logger;
            this._mediator = mediator;
        }

        #endregion

        [HttpGet(Name ="GetCanonicalCustomer")]
        public async Task<ActionResult> GetCanonicalCustomer(int customerId)
        {
            _logger.LogInformation("Canonical Customer Controller : GetById {0}", customerId);

            var query = new GetCanonicalCustomerByIdRequest(customerId);

            GetCanonicalCustomerByIdResponse response = await _mediator.Send(query);

            if (response.CanonicalCustomer is null) return NotFound();

            return Ok(response.CanonicalCustomer);
        }

        [HttpPost(Name = "InsertCanonicalCustomer")]
        public async Task<ActionResult> InsertCanonicalCustomer([FromBody] CanonicalCustomerModel customer)
        {
            _logger.LogInformation("Canonical Customer Controller : Insert - Id : {0}", customer.CanonicalCustomerId);

            var request = new InsertCanonicalCustomerRequest(customer);

            InsertCanonicalCustomerResponse response = await _mediator.Send(request);

            if (response.CanonicalCustomer is null) return NotFound();

            return Ok(response.CanonicalCustomer);
        }

        [HttpPut(Name = "UpdateCanonicalCustomer")]
        public async Task<ActionResult> UpdateCanonicalCustomer([FromBody] CanonicalCustomerModel customer)
        {
            throw new NotImplementedException();
        }
        
        [HttpDelete(Name = "DeleteCanonicalCustomer")]
        public async Task<ActionResult> DeleteCanonicalCustomer(int id)
        {
            throw new NotImplementedException();
        }
        
    }
}
