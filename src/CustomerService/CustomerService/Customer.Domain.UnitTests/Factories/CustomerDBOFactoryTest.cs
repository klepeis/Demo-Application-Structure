﻿using Customer.Domain.Factories;
using Customer.Domain.Profile.BusinessObjects;
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
            ICustomerProfileBO actual = customerBOFactory.CreateCustomerProfileBO();

            // Assert
            Assert.IsInstanceOfType(actual, typeof(CustomerProfileBO));
        }

        #endregion
    }
}