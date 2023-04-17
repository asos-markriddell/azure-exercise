using Application.Contracts;
using MediatR;

namespace Application.Customers.Queries.GetCustomer
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdRequest, GetCustomerByIdResponse>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerByIdHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<GetCustomerByIdResponse> Handle(GetCustomerByIdRequest request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerById(request.CustomerId);

            GetCustomerByIdResponse response = new GetCustomerByIdResponse(customer);

            return await Task.FromResult(response);
        }
    }
}
