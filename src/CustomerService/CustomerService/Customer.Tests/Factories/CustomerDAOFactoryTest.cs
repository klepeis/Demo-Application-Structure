using Customer.Factories;
using Customer.Infrastructure.DbContexts;
using Customer.Profile.DataAccessObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Customer.Tests.Factories
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
            ICustomerProfileDAO actual = customerDAOFactory.CreateCustomerProfileDAO();

            // Assert
            Assert.IsInstanceOfType(actual, typeof(CustomerProfileDAO));
        }

        #endregion
    }
}
