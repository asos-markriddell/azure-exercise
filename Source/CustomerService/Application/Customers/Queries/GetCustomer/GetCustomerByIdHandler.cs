using Application.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Customers.Queries.GetCustomer
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdRequest, GetCustomerByIdResponse>
    {
        #region "Properties"

        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<GetCustomerByIdHandler> _logger;

        #endregion

        #region "Constructors"

        public GetCustomerByIdHandler(ICustomerRepository customerRepository, ILogger<GetCustomerByIdHandler> logger)
        {
            _customerRepository = customerRepository;
            _logger = logger;
        }

        #endregion

        #region "Handlers"

        public async Task<GetCustomerByIdResponse> Handle(GetCustomerByIdRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"[{DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm:ss")}] Get Customer By Id : {request.CustomerId}");

            try
            {
                var customer = await _customerRepository.GetCustomerById(request.CustomerId);

                _logger.LogInformation($"[{DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm:ss")}] Retrieved Customer By Id : {request.CustomerId}");

                GetCustomerByIdResponse response = new GetCustomerByIdResponse(customer);

                return await Task.FromResult(response);
            }
            catch (InvalidOperationException ex)
            {
                var message = $"[{DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm:ss")}] Customer with Id {request.CustomerId} not found";

                _logger.LogError(message, ex);

                throw new InvalidOperationException(message, ex);
            }
        }

        #endregion
    }
}
