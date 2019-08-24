using Customer.Factories;
using Customer.Profile.BusinessObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Customer.Tests.Factories
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
            ICustomerProfileBO actual = customerBOFactory.CreateCustomerProfileBO();

            // Assert
            Assert.IsInstanceOfType(actual, typeof(CustomerProfileBO));
        }

        #endregion
    }
}
