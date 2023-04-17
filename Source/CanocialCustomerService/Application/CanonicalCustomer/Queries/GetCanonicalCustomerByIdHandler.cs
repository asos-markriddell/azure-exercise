using Application.Contracts;
using MediatR;

namespace Application.CanonicalCustomer.Queries
{
    public class GetCanonicalCustomerByIdHandler : IRequestHandler<GetCanonicalCustomerByIdRequest, GetCanonicalCustomerByIdResponse>
    {
        private readonly ICanonicalCustomerRepository _repository;
        
        public GetCanonicalCustomerByIdHandler(ICanonicalCustomerRepository canonicalCustomerRepository)
        {
            _repository = canonicalCustomerRepository;
        }
        
        public async Task<GetCanonicalCustomerByIdResponse> Handle(GetCanonicalCustomerByIdRequest request, CancellationToken cancellationToken)
        {
            var canonicalCustomer = await _repository.GetCanonicalCustomer(request.CanonicalCustomerId);
            var response = new GetCanonicalCustomerByIdResponse(canonicalCustomer);
            return await Task.FromResult(response);
        }
    }
}
