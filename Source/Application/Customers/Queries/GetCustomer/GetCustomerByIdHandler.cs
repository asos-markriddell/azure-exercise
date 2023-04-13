using Application.Contracts;
using Domain.Models.Dto;
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

        public Task<GetCustomerByIdResponse> Handle(GetCustomerByIdRequest request, CancellationToken cancellationToken)
        {
            CustomerDto customer =  _customerRepository.GetCustomerById(request.CustomerId);

            GetCustomerByIdResponse response = new GetCustomerByIdResponse() { Customer = customer };

            return Task.FromResult(response);
        }
    }
}
