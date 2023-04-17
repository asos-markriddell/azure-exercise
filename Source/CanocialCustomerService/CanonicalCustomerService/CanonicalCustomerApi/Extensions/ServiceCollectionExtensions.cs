using Application.Contracts;
using AutoMapper;
using Data;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CanonicalCustomerApi.Extensions
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

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            // Add Db Context
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });
            
            // Auto Mapper
            IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
            services.AddSingleton(mapper);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Repositories
            services.AddTransient<ICanonicalCustomerRepository, CanonicalCustomerRepository>();

            return services;
        }

    }
}
