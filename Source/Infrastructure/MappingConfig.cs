using AutoMapper;
using Domain.Models;
using Domain.Models.Dto;

namespace Infrastructure
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Customer, CustomerDto>();
                config.CreateMap<CustomerDto, Customer>();
            });

            return mappingConfig;
        }
    }
}
