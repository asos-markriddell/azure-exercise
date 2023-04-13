using Application.Contracts;
using AutoMapper;
using Domain.Models;
using Domain.Models.Dto;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public CustomerRepository(DataContext dbContext, IMapper mapper, ILogger<CustomerRepository> logger)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
            this._logger = logger;
        }

        public CustomerDto GetCustomerById(int id)
        {
            Customer customer = _dbContext.Customers.
                Include(c => c.Addresses).
                Include(c => c.Contacts).
                Single(c => c.CustomerId == id);

            return _mapper.Map<CustomerDto>(customer);
        }
    }
}
