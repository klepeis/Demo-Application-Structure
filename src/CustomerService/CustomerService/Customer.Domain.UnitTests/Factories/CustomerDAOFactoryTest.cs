using Customer.Domain.Factories;
using Customer.Domain.Infrastructure;
using Customer.Domain.CustomerModule.DataAccessObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Customer.Domain.UnitTests.Factories
{
    [TestClass]
    public class CustomerDAOFactoryTest
    {
        #region CreateCustomerProfileDAO

        [TestMethod]
        public void CreateCustomerProfileDAO_Success()
        {
            // Arrange
            Mock<CustomerDbContext> mockCustomerDbContext = new Mock<CustomerDbContext>();

            // Act
            ICustomerDAOFactory customerDAOFactory = new CustomerDAOFactory(mockCustomerDbContext.Object);
            ICustomerDAO actual = customerDAOFactory.CreateCustomerProfileDAO();

            // Assert
            Assert.IsInstanceOfType(actual, typeof(CustomerDAO));
        }

        #endregion
    }
}
