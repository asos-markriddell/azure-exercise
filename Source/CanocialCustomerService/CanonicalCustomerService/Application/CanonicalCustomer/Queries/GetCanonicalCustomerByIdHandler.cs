using Application.CanonicalCustomer.Commands;
using MediatR;

namespace Application.CanonicalCustomer.Queries
{
    public class GetCanonicalCustomerByIdHandler : IRequestHandler<GetCanonicalCustomerByIdRequest, GetCanonicalCustomerByIdResponse>
    {
        public Task<GetCanonicalCustomerByIdResponse> Handle(GetCanonicalCustomerByIdRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
