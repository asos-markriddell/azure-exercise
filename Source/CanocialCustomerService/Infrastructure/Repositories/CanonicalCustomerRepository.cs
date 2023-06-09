﻿using Application.Contracts;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Data;
using Data.Entities;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<CanonicalCustomerModel> GetCanonicalCustomer(int id)
        {
            var customer = await _dbContext.CanonicalCustomer.SingleOrDefaultAsync(c => c.CanonicalCustomerId == id);

            _logger.LogInformation($"Customer with id {id} {(customer == null ? "not found" : "returned")}");

            return _mapper.Map<CanonicalCustomerModel>(customer);
        }

        public CanonicalCustomerModel InsertCanonicalCustomer(CanonicalCustomerModel canonicalCustomerDto)
        {
            var customer = _mapper.Map<CanonicalCustomer>(canonicalCustomerDto);

            _dbContext.CanonicalCustomer.Add(customer);

            if (_dbContext.SaveChanges() > 0) 
                _logger.LogInformation($"Inserted Canonical Customer with Id {customer.CanonicalCustomerId} to database");

            return _mapper.Map<CanonicalCustomerModel>(customer);
        }

        public CanonicalCustomerModel UpdateCanonicalCustomer(CanonicalCustomerModel canonicalCustomerDto)
        {
            var customer = _dbContext.CanonicalCustomer.Single(c => c.CanonicalCustomerId == canonicalCustomerDto.CanonicalCustomerId);

            _mapper.Map(canonicalCustomerDto, customer);

            if (_dbContext.SaveChanges() > 0)
                _logger.LogInformation($"Updated Canonical Customer with Id {customer.CanonicalCustomerId} in database");

            return _mapper.Map<CanonicalCustomerModel>(customer);
        }

        public void DeleteCanonicalCustomer(int id)
        {
            var customer = _dbContext.CanonicalCustomer.Single(c => c.CanonicalCustomerId == id);

            if (customer == null)
            {
                _logger.LogInformation($"Canonical Customer with Id {id} not found");
                return;
            }

            _dbContext.CanonicalCustomer.Remove(customer);

            if(_dbContext.SaveChanges() > 0)
                _logger.LogInformation($"Deleted Canonical Customer with Id {id} in database");
        }
    }
}
