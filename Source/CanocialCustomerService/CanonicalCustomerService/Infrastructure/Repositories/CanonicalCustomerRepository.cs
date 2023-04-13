using Application.Contracts;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Data;
using Domain.Models;

namespace Infrastructure.Repositories
{
    public class CanonicalCustomerRepository : ICanonicalCustomerRepository
    {
        private readonly DataContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public CanonicalCustomerRepository(DataContext dbContext, IMapper mapper, ILogger<CanonicalCustomerRepository> logger)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
            this._logger = logger;
        }

        public CanonicalCustomerDto GetCanonicalCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertCanonicalCustomer(CanonicalCustomerDto dto)
        {
            throw new NotImplementedException();
        }

        public void UpdateCanonicalCustomer(CanonicalCustomerDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
