using Application.Customers.Queries.GetCustomer;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(c =>
                c.RegisterServicesFromAssemblyContaining<GetCustomerByIdHandler>
                    ());

            return services;
        }
    }
}
