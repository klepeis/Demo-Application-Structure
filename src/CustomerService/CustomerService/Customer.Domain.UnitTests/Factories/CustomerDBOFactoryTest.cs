using Customer.Domain.Factories;
using Customer.Domain.Customer.BusinessObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Customer.Domain.UnitTests.Factories
{
    [TestClass]
    public class CustomerBOFactoryTest
    {
        #region CreateCustomerProfileBO

        [TestMethod]
        public void CreateCustomerProfileBO_Success()
        {
            // Arrange
            Mock<ICustomerDAOFactory> mockICustomerDAOFactory = new Mock<ICustomerDAOFactory>();

            // Act
            ICustomerBOFactory customerBOFactory = new CustomerBOFactory(mockICustomerDAOFactory.Object);
            ICustomerBO actual = customerBOFactory.CreateCustomerProfileBO();

            // Assert
            Assert.IsInstanceOfType(actual, typeof(CustomerBO));
        }

        #endregion
    }
}
