using Customer.Domain.Customer.BusinessObjects;
using Customer.Domain.Customer.BusinessObjects.BusinessModels;
using Customer.Domain.Customer.DataAccessObjects;
using Customer.Domain.Customer.DataAccessObjects.Models.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Customer.Domain.UnitTests.Profile.BusinessObjects
{
    [TestClass]
    public class CustomerProfileBOTests
    {
        #region AddProfile

        [TestMethod]
        public void AddProfile_Success()
        {
            // Arrange
            CustomerEntity seedData = new CustomerEntity()
            {
                CreatedDate = DateTime.Now,
                FirstName = "Test",
                Id = 123,
                LastName = "User",
                ModifiedDate = DateTime.Now
            };

            Mock<ICustomerDAO> mockCustomerProfileDAO = new Mock<ICustomerDAO>();
            mockCustomerProfileDAO.Setup(m => m.AddProfile(It.IsAny<CustomerEntity>()))
                .Returns(seedData);

            // Act
            CustomerBO customerProfileBO = new CustomerBO(mockCustomerProfileDAO.Object);
            Customer.BusinessObjects.BusinessModels.Customer actual = customerProfileBO.AddProfile(new Customer.BusinessObjects.BusinessModels.Customer()
            {
                FirstName = "Test",
                Id = 123,
                LastName = "User"
            });

            // Assert
            Customer.BusinessObjects.BusinessModels.Customer expected = seedData.ConvertToBusinessModel();

            Assert.AreEqual(expected.CreatedDate, actual.CreatedDate);
            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.LastName, actual.LastName);
        }

        #endregion

        #region DeleteProfile

        [TestMethod]
        public void DeleteProfile_Success()
        {
            // Arrange
            Mock<ICustomerDAO> mockCustomerProfileDAO = new Mock<ICustomerDAO>();
            mockCustomerProfileDAO.Setup(m => m.DeleteProfile(It.IsAny<CustomerEntity>()))
                .Verifiable();

            // Act
            CustomerBO customerProfileBO = new CustomerBO(mockCustomerProfileDAO.Object);
            customerProfileBO.DeleteProfile(123);

            // Assert
            mockCustomerProfileDAO.Verify(m => m.DeleteProfile(It.IsAny<CustomerEntity>()), Times.Once());
        }

        #endregion

        #region GetProfile

        [TestMethod]
        public void GetProfile_Success()
        {
            // Arrange
            CustomerEntity seedData = new CustomerEntity()
            {
                CreatedDate = DateTime.Now,
                FirstName = "Test",
                Id = 123,
                LastName = "User",
                ModifiedDate = DateTime.Now
            };

            Mock<ICustomerDAO> mockCustomerProfileDAO = new Mock<ICustomerDAO>();
            mockCustomerProfileDAO.Setup(m => m.GetProfile(It.IsAny<long>()))
                .Returns(seedData);

            // Act
            CustomerBO customerProfileBO = new CustomerBO(mockCustomerProfileDAO.Object);
            Customer.BusinessObjects.BusinessModels.Customer actual = customerProfileBO.GetProfile(123);

            // Assert
            Customer.BusinessObjects.BusinessModels.Customer expected = seedData.ConvertToBusinessModel();

            Assert.AreEqual(expected.CreatedDate, actual.CreatedDate);
            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.LastName, actual.LastName);
        }

        [TestMethod]
        public void GetProfile_NotFound_ReturnNull()
        {
            // Arrange
            Mock<ICustomerDAO> mockCustomerProfileDAO = new Mock<ICustomerDAO>();
            mockCustomerProfileDAO.Setup(m => m.GetProfile(It.IsAny<long>()))
                    .Returns((CustomerEntity)null);

            // Act
            CustomerBO customerProfileBO = new CustomerBO(mockCustomerProfileDAO.Object);
            Customer.BusinessObjects.BusinessModels.Customer actual = customerProfileBO.GetProfile(It.IsAny<long>());

            // Assert
            Assert.IsNull(actual);
        }

        #endregion

        #region UpdateProfile

        [TestMethod]
        public void UpdateProfile_Success()
        {
            // Arrange
            CustomerEntity seedData = new CustomerEntity()
            {
                CreatedDate = DateTime.Now,
                FirstName = "Test",
                Id = 123,
                LastName = "User",
                ModifiedDate = DateTime.Now
            };

            Mock<ICustomerDAO> mockCustomerProfileDAO = new Mock<ICustomerDAO>();
            mockCustomerProfileDAO.Setup(m => m.UpdateProfile(It.IsAny<CustomerEntity>()))
                .Returns(seedData);

            // Act
            CustomerBO customerProfileBO = new CustomerBO(mockCustomerProfileDAO.Object);
            Customer.BusinessObjects.BusinessModels.Customer actual = customerProfileBO.UpdateProfile(new Customer.BusinessObjects.BusinessModels.Customer()
            {
                FirstName = "Test",
                Id = 123,
                LastName = "User",
                ModifiedDate = DateTime.Now.AddDays(-1)
            });

            // Assert
            Customer.BusinessObjects.BusinessModels.Customer expected = seedData.ConvertToBusinessModel();

            Assert.AreEqual(expected.CreatedDate, actual.CreatedDate);
            Assert.AreEqual(expected.ModifiedDate, actual.ModifiedDate);
            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.LastName, actual.LastName);
        }

        #endregion
    }
}
