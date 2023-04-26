using AutoMapper;
using Data;
using Data.Entities;
using Domain.Models;
using FluentAssertions;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using Moq;

namespace UnitTests.Infrastructure.Repositories
{
    public class CustomerRepositoryTests
    {
        #region "Properties"

        private readonly ILogger _logger;
        private readonly DataContext _context;
        private readonly Mapper _mapper;
        private readonly Mock<ILogger<CustomerRepository>> _stubLogger;

        #endregion

        #region "Set Up"

        public CustomerRepositoryTests()
        {
            var _contextOptions = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase("BloggingControllerTest")
                .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            //using var context =
            _context = new DataContext(_contextOptions);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            _context.AddRange(
                new Customer()
                {
                    Forename = "John",
                    Surname = "Smith",
                    Email = "john.smith@asos.com",
                    Addresses = new[] { new Address()
                    {
                        AddressLine1 = "ASOS", AddressLine2 = "Third Floor", AddressLine3 = "Custom House", City = "Belfast", County = "Co. Antrim", Country = "N. Ireland", CustomerId = 1, PostalCode = "BT35 873"
                    } },
                    Contacts = new[]
                    {
                        new Contact()
                        {
                            HomeNumber = "02846 974123", MobileNumber = "07725 33698"
                        }
                    }
                });

            _context.SaveChanges();

            // Create Stubs
            _stubLogger = new Mock<ILogger<CustomerRepository>>();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Customer, CustomerModel>());

            _mapper = new Mapper(config);
        }

        #endregion

        #region "Tests"

        [Fact]
        public void GivenACustomerExists_WhenGetByIdIsInvoked_ThenTheCustomerIsReturned()
        {
            // Arrange
            var repository = new CustomerRepository(_context, _mapper, _stubLogger.Object);
            int customerId = 1;

            // Act
            Task<CustomerModel> customer = repository.GetCustomerById(customerId);
            
            // Assert
            customer.Result.Should().BeOfType<CustomerModel>();
            customer.Result.Forename = "John";
            customer.Result.Surname = "Smith";
            customer.Result.CustomerId = customerId;
            customer.Result.Email = "john.smith@asos.com";
        }

        [Fact] public void GivenACustomerDoesntExist_WhenGetByIdIsInvoked_ThenNullIsReturned()
        {
            // Arrange
            var repository = new CustomerRepository(_context, _mapper, _stubLogger.Object);
            int customerId = 0;

            // Act
            Task<CustomerModel> customer = repository.GetCustomerById(customerId);

            // Assert
            customer.Result.Should().BeNull();
        }

        #endregion

    }
}