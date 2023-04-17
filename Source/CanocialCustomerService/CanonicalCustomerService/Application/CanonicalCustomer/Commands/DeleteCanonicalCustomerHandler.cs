using Application.Contracts;
using MediatR;

namespace Application.CanonicalCustomer.Commands
{
    public class DeleteCanonicalCustomerHandler : IRequestHandler<DeleteCanonicalCustomerRequest, DeleteCanonicalCustomerResponse>
    {
        private readonly ICanonicalCustomerRepository _repository;

        public DeleteCanonicalCustomerHandler(ICanonicalCustomerRepository repository)
        {
            _repository = repository;
        }

        public Task<DeleteCanonicalCustomerResponse> Handle(DeleteCanonicalCustomerRequest request, CancellationToken cancellationToken)
        {
            _repository.DeleteCanonicalCustomer(request.CanonicalCustomerId);

            var response = new DeleteCanonicalCustomerResponse(request.CanonicalCustomerId);

            return Task.FromResult(response);
        }
    }
}
