using Application.Contracts;
using Application.Customers.Queries.GetCustomer;
using Data.Models;
using Domain.Models;
using Moq;

namespace UnitTests.Application.Customers
{
    public class GetCustomerByIdHandlerTests
    {
        private readonly Mock<ICustomerRepository> _stubCustomerRepository;

        private readonly GetCustomerByIdHandler _handler;

        public GetCustomerByIdHandlerTests()
        {
            // Set Up
            _stubCustomerRepository = new Mock<ICustomerRepository>();
            _handler = new GetCustomerByIdHandler(_stubCustomerRepository.Object);
        }

        [Fact]
        public void GivenAValidCustomerIdIsProvided_WhenTheHandlerIsCalled_ThenACustomerIsReturned()
        {
            // Arrange
            int customerId = 1;

            var address = new Address() { AddressId = 1, AddressLine1 = "ASOS", AddressLine2 = "Third Floor", AddressLine3 = "Custom House", City = "Belfast", County = "Co. Antrim", Country = "N. Ireland", CustomerId = customerId, PostalCode = "BT35 873" };

            var contact = new Contact() { ContactId = 1, CustomerId = customerId, HomeNumber = 0284697412, MobileNumber = 0772533698 };

            CustomerModel expectedResult = new CustomerModel()
            {
                CustomerId = customerId,
                Email = "john.smith@asos.com",
                Fullname = "John Smith",
                Addresses = new[] { address },
                Contacts = new[] { contact }
            };

            _stubCustomerRepository.Setup(x => x.GetCustomerById(customerId)).Returns(Task.FromResult(expectedResult));

            var getCustomerByIdRequest = new GetCustomerByIdRequest(customerId);

            // Act 
            var actualResult =  _handler.Handle(getCustomerByIdRequest, CancellationToken.None);

            // Assert
            Assert.Equal(expectedResult, actualResult.Result.Customer);
        }

        [Fact]
        public void GivenAnInvalidCustomerIdIsProvided_WhenTheHandlerIsCalled_ThenAnArgumentExceptionIsThrown()
        {
            // Arrange
            int customerId = -1;

            _stubCustomerRepository.Setup(x => x.GetCustomerById(customerId)).Throws(new InvalidOperationException("Sequence contains no elements"));

            var getCustomerByIdRequest = new GetCustomerByIdRequest(customerId);

            // Act & Assert
            Assert.ThrowsAsync<InvalidOperationException>(() => _handler.Handle(getCustomerByIdRequest, new CancellationToken()));
        }
    }
}