﻿using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(c =>
                c.RegisterServicesFromAssemblyContaining<
                        Application.CanonicalCustomer.Queries.GetCanonicalCustomerByIdHandler>
                    ());

            return services;
        }
    }
}