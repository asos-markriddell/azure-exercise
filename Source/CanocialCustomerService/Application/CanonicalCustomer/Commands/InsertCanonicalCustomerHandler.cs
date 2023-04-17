using Application.Contracts;
using MediatR;

namespace Application.CanonicalCustomer.Commands
{
    public class InsertCanonicalCustomerHandler : IRequestHandler<InsertCanonicalCustomerRequest, InsertCanonicalCustomerResponse>
    {
        private readonly ICanonicalCustomerRepository _repository;

        public InsertCanonicalCustomerHandler(ICanonicalCustomerRepository repository)
        {
            _repository = repository;
        }

        public Task<InsertCanonicalCustomerResponse> Handle(InsertCanonicalCustomerRequest request, CancellationToken cancellationToken)
        {
            var customer = _repository.InsertCanonicalCustomer(request.CanonicalCustomer);

            var response = new InsertCanonicalCustomerResponse(customer);

            return Task.FromResult(response);
        }
    }
}
