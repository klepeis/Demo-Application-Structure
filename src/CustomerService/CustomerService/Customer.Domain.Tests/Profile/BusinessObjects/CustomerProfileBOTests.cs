using Customer.Domain.Profile.BusinessObjects;
using Customer.Domain.Profile.BusinessObjects.Models;
using Customer.Domain.Profile.DataAccessObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using ProfileDataAccess = Customer.Domain.Profile.DataAccessObjects;

namespace Customer.Domain.Tests.Profile.BusinessObjects
{
    [TestClass]
    public class CustomerProfileBOTests
    {
        #region AddProfile

        [TestMethod]
        public void AddProfile_Success()
        {
            // Arrange
            ProfileDataAccess.Models.CustomerProfile seedData = new ProfileDataAccess.Models.CustomerProfile()
            {
                CreatedDate = DateTime.Now,
                FirstName = "Test",
                Id = 123,
                LastName = "User",
                ModifiedDate = DateTime.Now
            };

            Mock<ICustomerProfileDAO> mockCustomerProfileDAO = new Mock<ICustomerProfileDAO>();
            mockCustomerProfileDAO.Setup(m => m.AddProfile(It.IsAny<ProfileDataAccess.Models.CustomerProfile>()))
                .Returns(seedData);

            // Act
            CustomerProfileBO customerProfileBO = new CustomerProfileBO(mockCustomerProfileDAO.Object);
            CustomerProfile actual = customerProfileBO.AddProfile(new CustomerProfile()
            {
                FirstName = "Test",
                Id = 123,
                LastName = "User"
            });

            // Assert
            CustomerProfile expected = seedData.ConvertToBusinessModel();

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
            Mock<ICustomerProfileDAO> mockCustomerProfileDAO = new Mock<ICustomerProfileDAO>();
            mockCustomerProfileDAO.Setup(m => m.DeleteProfile(It.IsAny<ProfileDataAccess.Models.CustomerProfile>()))
                .Verifiable();

            // Act
            CustomerProfileBO customerProfileBO = new CustomerProfileBO(mockCustomerProfileDAO.Object);
            customerProfileBO.DeleteProfile(123);

            // Assert
            mockCustomerProfileDAO.Verify(m => m.DeleteProfile(It.IsAny<ProfileDataAccess.Models.CustomerProfile>()), Times.Once());
        }

        #endregion

        #region GetProfile

        [TestMethod]
        public void GetProfile_Success()
        {
            // Arrange
            ProfileDataAccess.Models.CustomerProfile seedData = new ProfileDataAccess.Models.CustomerProfile()
            {
                CreatedDate = DateTime.Now,
                FirstName = "Test",
                Id = 123,
                LastName = "User",
                ModifiedDate = DateTime.Now
            };

            Mock<ICustomerProfileDAO> mockCustomerProfileDAO = new Mock<ICustomerProfileDAO>();
            mockCustomerProfileDAO.Setup(m => m.GetProfile(It.IsAny<long>()))
                .Returns(seedData);

            // Act
            CustomerProfileBO customerProfileBO = new CustomerProfileBO(mockCustomerProfileDAO.Object);
            CustomerProfile actual = customerProfileBO.GetProfile(123);

            // Assert
            CustomerProfile expected = seedData.ConvertToBusinessModel();

            Assert.AreEqual(expected.CreatedDate, actual.CreatedDate);
            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.LastName, actual.LastName);
        }

        [TestMethod]
        public void GetProfile_NotFound_ReturnNull()
        {
            // Arrange
            Mock<ICustomerProfileDAO> mockCustomerProfileDAO = new Mock<ICustomerProfileDAO>();
            mockCustomerProfileDAO.Setup(m => m.GetProfile(It.IsAny<long>()))
                    .Returns((ProfileDataAccess.Models.CustomerProfile)null);

            // Act
            CustomerProfileBO customerProfileBO = new CustomerProfileBO(mockCustomerProfileDAO.Object);
            CustomerProfile actual = customerProfileBO.GetProfile(It.IsAny<long>());

            // Assert
            Assert.IsNull(actual);
        }

        #endregion

        #region UpdateProfile

        [TestMethod]
        public void UpdateProfile_Success()
        {
            // Arrange
            ProfileDataAccess.Models.CustomerProfile seedData = new ProfileDataAccess.Models.CustomerProfile()
            {
                CreatedDate = DateTime.Now,
                FirstName = "Test",
                Id = 123,
                LastName = "User",
                ModifiedDate = DateTime.Now
            };

            Mock<ICustomerProfileDAO> mockCustomerProfileDAO = new Mock<ICustomerProfileDAO>();
            mockCustomerProfileDAO.Setup(m => m.UpdateProfile(It.IsAny<ProfileDataAccess.Models.CustomerProfile>()))
                .Returns(seedData);

            // Act
            CustomerProfileBO customerProfileBO = new CustomerProfileBO(mockCustomerProfileDAO.Object);
            CustomerProfile actual = customerProfileBO.UpdateProfile(new CustomerProfile()
            {
                FirstName = "Test",
                Id = 123,
                LastName = "User",
                ModifiedDate = DateTime.Now.AddDays(-1)
            });

            // Assert
            CustomerProfile expected = seedData.ConvertToBusinessModel();

            Assert.AreEqual(expected.CreatedDate, actual.CreatedDate);
            Assert.AreEqual(expected.ModifiedDate, actual.ModifiedDate);
            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.LastName, actual.LastName);
        }

        #endregion
    }
}
