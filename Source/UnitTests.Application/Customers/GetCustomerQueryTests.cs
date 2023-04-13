using Application.Contracts;
using Application.Customers.Queries.GetCustomer;
using Domain.Models;
using Moq;

namespace UnitTests.Application.Customers
{
    public class GetCustomerQueryTests
    {
        private readonly Mock<ICustomerRepository> _stubCustomerRepository;
      //  private IGetCustomerQuery _getCustomerQuery;

        public GetCustomerQueryTests()
        {
            //// Set Up

            //_stubCustomerRepository = new Mock<ICustomerRepository>();
            //_getCustomerQuery = new GetCustomerQuery(_stubCustomerRepository.Object);
        }

        //[Fact]
        //public void GivenAValidCustomerIdIsProvided_WhenExecuted_ThenACustomerIsReturned()
        //{
        //    // Arrange
        //    int customerId = 1;
        //    Customer expectedResult = new Customer()
        //    {
        //        CustomerId = customerId,
        //        DateOfBirth = DateTime.Parse("01-01-2000"), Email = "john.smith@asos.com", Forename = "John",
        //        Surname = "Smith"
        //    };

        //    _stubCustomerRepository.Setup(x => x.GetAsync(customerId)).ReturnsAsync(expectedResult);

        //    // Act 
        //    var actualResult = _getCustomerQuery.Execute(customerId);

        //    // Assert
        //    Assert.Equal(expectedResult, actualResult.Result);
        //}

        //[Fact]
        //[Obsolete]
        //public void GivenAnInvalidCustomerIdIsProvided_WhenExecuted_ThenAnArgumentExceptionIsThrown()
        //{
        //    // Arrange
        //    int customerId = -1;

        //    // Act
        //    Action action = () => _getCustomerQuery.Execute(customerId);

        //    // Assert
        //    Assert.Throws<ArgumentException>(action);
        //}
    }
}