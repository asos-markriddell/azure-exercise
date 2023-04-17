using Application.Contracts;
using MediatR;

namespace Application.CanonicalCustomer.Commands
{
    public class UpdateCanonicalCustomerHandler : IRequestHandler<UpdateCanonicalCustomerRequest, UpdateCanonicalCustomerResponse>
    {
        private readonly ICanonicalCustomerRepository _repository;

        public UpdateCanonicalCustomerHandler(ICanonicalCustomerRepository repository)
        {
            _repository = repository;
        }

        public Task<UpdateCanonicalCustomerResponse> Handle(UpdateCanonicalCustomerRequest request, CancellationToken cancellationToken)
        {
            _repository.UpdateCanonicalCustomer(request.CanonicalCustomer);

            var response = new UpdateCanonicalCustomerResponse(request.CanonicalCustomer.CanonicalCustomerId);

            return Task.FromResult(response);
        }
    }
}
