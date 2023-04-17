using AutoMapper;
using Data.Models;
using Domain.Models;

namespace Infrastructure
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Customer, CustomerModel>();
                config.CreateMap<CustomerModel, Customer>();
            });

            return mappingConfig;
        }
    }
}
