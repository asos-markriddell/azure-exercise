using Application.Contracts;
using AutoMapper;
using Domain.Models;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        #region "Properties"

        private readonly DataContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        #endregion

        #region "Constructors"

        public CustomerRepository(DataContext dbContext, IMapper mapper, ILogger<CustomerRepository> logger)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
            this._logger = logger;
        }

        #endregion

        #region "Methods"

        public async Task<CustomerModel> GetCustomerById(int id)
        {
            Customer customer = await _dbContext.Customers.Include(c => c.Addresses).
                Include(c => c.Contacts).
                SingleOrDefaultAsync(c => c.CustomerId == id);

            _logger.LogInformation($"Customer with id {id} {(customer == null ? "not found" : "returned")}");

            return _mapper.Map<CustomerModel>(customer);
        }

        #endregion
    }
}
