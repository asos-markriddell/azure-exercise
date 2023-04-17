using Application.CanonicalCustomer.Commands;
using MediatR;

namespace Application.CanonicalCustomer.Queries
{
    public class GetCanonicalCustomerByIdRequest : IRequest<GetCanonicalCustomerByIdResponse>
    {
        public GetCanonicalCustomerByIdRequest(int id)
        {
            CanonicalCustomerId = id;
        }

        public int CanonicalCustomerId { get; set; }
    };
}
