using Application.CanonicalCustomer.Queries;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CanonicalCustomerApi.Controllers
{
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

        [HttpGet(Name="GetCanonicalCustomer")]
        public async Task<ActionResult> GetCanonicalCustomer(int id)
        {
            _logger.LogInformation("Customer Controller : Get By Id {0}", id);

            var query = new GetCanonicalCustomerByIdRequest(id);

            GetCanonicalCustomerByIdResponse response = await _mediator.Send(query);

            if (response.CanonicalCustomer is null) return NotFound();

            return Ok(response.CanonicalCustomer);
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
