using Application.Contracts;
using Application.Customers.Queries.GetCustomer;
using Domain.Models;
using Moq;

namespace UnitTests.Application.Customers
{
    public class GetCustomerQueryTests
    {
        private readonly Mock<ICustomerRepository> _stubCustomerRepository;

        public GetCustomerQueryTests()
        {
            // Set Up

            _stubCustomerRepository = new Mock<ICustomerRepository>();
        }

        [Fact]
        public void GivenACustomerIdIsProvided_WhenExecuted_ThenACustomerIsReturned()
        {
            // Arrange
            int customerId = 1;
            Customer expectedResult = new Customer()
            {
                CustomerId = customerId,
                DateOfBirth = DateTime.Parse("01-01-2000"), Email = "john.smith@asos.com", Forename = "John",
                Surname = "Smith"
            };

            _stubCustomerRepository.Setup(x => x.GetAsync(customerId)).ReturnsAsync(expectedResult);

            IGetCustomerQuery getCustomerQuery = new GetCustomerQuery(_stubCustomerRepository.Object);

            // Act 
            var actualResult = getCustomerQuery.Execute(customerId);

            // Assert
            Assert.Equal(expectedResult, actualResult.Result);
        }
    }
}