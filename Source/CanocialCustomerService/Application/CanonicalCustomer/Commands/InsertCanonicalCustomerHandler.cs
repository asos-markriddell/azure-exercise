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
            _repository.InsertCanonicalCustomer(request.CanonicalCustomer);

            var response = new InsertCanonicalCustomerResponse(request.CanonicalCustomer.CanonicalCustomerId);

            return Task.FromResult(response);
        }
    }
}
