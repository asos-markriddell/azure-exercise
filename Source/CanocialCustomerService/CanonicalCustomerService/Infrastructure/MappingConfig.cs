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
                config.CreateMap<CanonicalCustomer, CanonicalCustomerDto>();
                config.CreateMap<CanonicalCustomerDto, CanonicalCustomer>();
            });

            return mappingConfig;
        }
    }
}
