using Application.Contracts;
using Application.Customers.Queries.GetCustomer;
using Data.Entities;
using Domain.Models;
using Microsoft.Extensions.Logging;
using Moq;

namespace UnitTests.Application.Customers
{
    public class GetCustomerByIdHandlerTests
    {
        #region "Properties"

        private readonly Mock<ICustomerRepository> _stubCustomerRepository;
        private readonly GetCustomerByIdHandler _handler;
        private readonly Mock<ILogger<GetCustomerByIdHandler>> _logger;

        #endregion

        #region "Set Up"

        public GetCustomerByIdHandlerTests()
        {
            _stubCustomerRepository = new Mock<ICustomerRepository>();
            _logger = new Mock<ILogger<GetCustomerByIdHandler>>();
            _handler = new GetCustomerByIdHandler(_stubCustomerRepository.Object, _logger.Object);
        }

        #endregion

        #region "Tests"

        [Fact]
        public void GivenACustomerExists_WhenTheHandlerIsCalled_ThenTheCustomerIsReturned()
        {
            // Arrange
            int customerId = 1;

            var address = new Address() { AddressId = 1, AddressLine1 = "ASOS", AddressLine2 = "Third Floor", AddressLine3 = "Custom House", City = "Belfast", County = "Co. Antrim", Country = "N. Ireland", CustomerId = customerId, PostalCode = "BT35 873" };

            var contact = new Contact() { ContactId = 1, CustomerId = customerId, HomeNumber = "02846 974123", MobileNumber = "07725 33698" };

            CustomerModel expectedResult = new CustomerModel()
            {
                CustomerId = customerId, Email = "john.smith@asos.com", Forename = "John", Surname = "Smith", Addresses = new[] { address }, Contacts = new[] { contact }
            };

            _stubCustomerRepository.Setup(x => x.GetCustomerById(customerId)).Returns(Task.FromResult(expectedResult));

            var getCustomerByIdRequest = new GetCustomerByIdRequest(customerId);

            // Act 
            var actualResult =  _handler.Handle(getCustomerByIdRequest, CancellationToken.None);

            // Assert
            Assert.Equal(expectedResult, actualResult.Result.Customer);
        }

        [Fact]
        public void GivenACustomerExists_WhenTheHandlerIsCalled_ThenAppropriateInformationIsLogged()
        {
            // Arrange
            int customerId = 1;
            var expectedResult = new CustomerModel() { CustomerId = customerId, Email = "john.smith@asos.com" };

            _stubCustomerRepository.Setup(x => x.GetCustomerById(customerId)).Returns(Task.FromResult(expectedResult));

            var getCustomerByIdRequest = new GetCustomerByIdRequest(customerId);

            // Act 
            var actualResult = _handler.Handle(getCustomerByIdRequest, CancellationToken.None);

            // Assert
            _logger.Verify(l => l.Log(LogLevel.Information, It.IsAny<EventId>(), It.Is<It.IsAnyType>((v, _) =>
                        v.ToString()
                            .Equals(
                                $"[{DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm:ss")}] Get Customer By Id : {customerId}")),
                    null,
                    It.IsAny<Func<It.IsAnyType, Exception, string>>())
                , Times.Once);

            _logger.Verify(l => l.Log(LogLevel.Information, It.IsAny<EventId>(), It.Is<It.IsAnyType>((v, _) =>
                        v.ToString()
                            .Equals(
                                $"[{DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm:ss")}] Retrieved Customer By Id : {customerId}")),
                    null,
                    It.IsAny<Func<It.IsAnyType, Exception, string>>())
                , Times.Once);
        }

        [Fact]
        public void GivenAnCustomerDoesntExist_WhenTheHandlerIsCalled_ThenAnArgumentExceptionIsThrown()
        {
            // Arrange
            int customerId = 1;

            _stubCustomerRepository.Setup(x => x.GetCustomerById(customerId)).Throws(new InvalidOperationException("Sequence contains no elements"));

            var getCustomerByIdRequest = new GetCustomerByIdRequest(customerId);

            // Act & Assert
            Assert.ThrowsAsync<InvalidOperationException>(() => _handler.Handle(getCustomerByIdRequest, new CancellationToken()));
        }

        [Fact]
        public void GivenAnCustomerDoesntExist_WhenTheHandlerIsCalled_ThenAnErrorIsLogged()
        {
            // Arrange
            int customerId = 1;

            _stubCustomerRepository.Setup(x => x.GetCustomerById(customerId)).Throws(new InvalidOperationException("Sequence contains no elements"));

            var getCustomerByIdRequest = new GetCustomerByIdRequest(customerId);

            // Act
            var result = _handler.Handle(getCustomerByIdRequest, new CancellationToken());

            // Assert
            _logger.Verify(l => l.Log(LogLevel.Error, It.IsAny<EventId>(), It.Is<It.IsAnyType>((v, _) =>
                        v.ToString()
                            .Equals(
                                $"[{DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm:ss")}] Customer with Id {customerId} not found")),
                    null,
                    It.IsAny<Func<It.IsAnyType, Exception, string>>())
                , Times.Once);
        }

        #endregion
    }
}