using Customer.API.Controllers;
using Customer.Profile.BusinessObjects;
using Customer.Profile.BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Net;

namespace Customer.API.Tests.Controllers
{
    [TestClass]
    public class ProfileControllerTests
    {
        #region GetCustomerProfile

        [TestMethod]
        public void GetCustomerProfile_Success200Ok()
        {
            // Arrange
            CustomerProfile expectedContent = new CustomerProfile()
            {
                CreatedDate = DateTime.Now,
                FirstName = "Test",
                Id = 123,
                LastName = "User",
                ModifiedDate = DateTime.Now
            };

            Mock<ICustomerProfileBO> mockCustomerProfileBO = new Mock<ICustomerProfileBO>();
            mockCustomerProfileBO.Setup(m => m.GetProfile(It.IsAny<long>()))
                .Returns(expectedContent);

            // Act
            ProfileController controller = new ProfileController(mockCustomerProfileBO.Object);
            ActionResult<CustomerProfile> response = controller.GetCustomerProfile(It.IsAny<long>());

            // Assert
            var actualStatusCode = (response.Result as ObjectResult).StatusCode;
            Assert.AreEqual((int)HttpStatusCode.OK, actualStatusCode);

            var actualContent = (CustomerProfile)Convert.ChangeType((response.Result as ObjectResult)?.Value, typeof(CustomerProfile));
            Assert.AreEqual(expectedContent, actualContent);
        }

        #endregion

        #region AddCustomerProfile_Success201

        [TestMethod]
        public void AddCustomerProfile_Success201Created()
        {

            // Arrange
            CustomerProfile expectedContent = new CustomerProfile()
            {
                CreatedDate = DateTime.Now,
                FirstName = "Test",
                Id = 123,
                LastName = "User",
                ModifiedDate = DateTime.Now
            };

            Mock<ICustomerProfileBO> mockCustomerProfileBO = new Mock<ICustomerProfileBO>();
            mockCustomerProfileBO.Setup(m => m.AddProfile(It.IsAny<CustomerProfile>()))
                .Returns(expectedContent);

            // Act
            ProfileController controller = new ProfileController(mockCustomerProfileBO.Object);
            ActionResult<CustomerProfile> response = controller.AddCustomerProfile(new CustomerProfile
            {
                FirstName = "Test",
                LastName = "User"
            });

            // Assert
            var actualStatusCode = (response.Result as ObjectResult).StatusCode;
            Assert.AreEqual((int)HttpStatusCode.Created, actualStatusCode);

            var actualContent = (CustomerProfile)Convert.ChangeType((response.Result as ObjectResult)?.Value, typeof(CustomerProfile));
            Assert.AreEqual(expectedContent, actualContent);
        }

        #endregion

        #region UpdateCustomerProfile

        [TestMethod]
        public void UpdateCustomerProfile_Success204NoContent()
        {
            // Arrange
            CustomerProfile expectedContent = new CustomerProfile()
            {
                CreatedDate = DateTime.Now,
                FirstName = "Test",
                Id = 123,
                LastName = "User",
                ModifiedDate = DateTime.Now
            };

            Mock<ICustomerProfileBO> mockCustomerProfileBO = new Mock<ICustomerProfileBO>();
            mockCustomerProfileBO.Setup(m => m.UpdateProfile(It.IsAny<CustomerProfile>()))
                .Returns(expectedContent);

            // Act
            ProfileController controller = new ProfileController(mockCustomerProfileBO.Object);
            ActionResult response = controller.UpdateCustomerProfile(123, new CustomerProfile()
            {
                FirstName = "Test",
                Id = 123,
                LastName = "User",
            });

            // Assert
            var actualStatusCode = (response as StatusCodeResult).StatusCode;
            Assert.AreEqual((int)HttpStatusCode.NoContent, actualStatusCode);
        }

        [TestMethod]
        public void UpdateCustomerProfile_Success400BadRequest()
        {
            // Arrange
            CustomerProfile expectedContent = new CustomerProfile()
            {
                CreatedDate = DateTime.Now,
                FirstName = "Test",
                Id = 123,
                LastName = "User",
                ModifiedDate = DateTime.Now
            };

            Mock<ICustomerProfileBO> mockCustomerProfileBO = new Mock<ICustomerProfileBO>();
            mockCustomerProfileBO.Setup(m => m.UpdateProfile(It.IsAny<CustomerProfile>()))
                .Returns(expectedContent);

            // Act
            ProfileController controller = new ProfileController(mockCustomerProfileBO.Object);
            ActionResult response = controller.UpdateCustomerProfile(123, new CustomerProfile()
            {
                FirstName = "Test",
                Id = 999,
                LastName = "User",
            });

            // Assert
            var actualStatusCode = (response as StatusCodeResult).StatusCode;
            Assert.AreEqual((int)HttpStatusCode.BadRequest, actualStatusCode);
        }

        #endregion

        #region DeleteCustomerProfile

        [TestMethod]
        public void DeleteCustomerProfile_Success204NoContent()
        {
            // Arrange
            Mock<ICustomerProfileBO> mockCustomerProfileBO = new Mock<ICustomerProfileBO>();
            mockCustomerProfileBO.Setup(m => m.DeleteProfile(It.IsAny<long>())).Verifiable();

            // Act
            ProfileController controller = new ProfileController(mockCustomerProfileBO.Object);
            ActionResult response = controller.DeleteCustomerProfile(It.IsAny<long>());

            // Assert
            var actualStatusCode = (response as StatusCodeResult).StatusCode;
            Assert.AreEqual((int)HttpStatusCode.NoContent, actualStatusCode);

            mockCustomerProfileBO.Verify(m => m.DeleteProfile(It.IsAny<long>()), Times.Once);
        }

        //[TestMethod]
        //public void UpdateCustomerProfile_Success404NotFound()
        //{
        //    // Arrange
        //    Mock<ICustomerProfileBO> mockCustomerProfileBO = new Mock<ICustomerProfileBO>();
        //    mockCustomerProfileBO.Setup(m => m.UpdateProfile(It.IsAny<CustomerProfile>()))
        //        .Returns((CustomerProfile)null);

        //    // Act
        //    ProfileController controller = new ProfileController(mockCustomerProfileBO.Object);
        //    ActionResult response = controller.DeleteCustomerProfile(It.IsAny<long>());

        //    // Assert
        //    var actualStatusCode = (response as StatusCodeResult).StatusCode;
        //    Assert.AreEqual((int)HttpStatusCode.NotFound, actualStatusCode);

        //    mockCustomerProfileBO.Verify(m => m.DeleteProfile(It.IsAny<long>()), Times.Once);
        //}

        #endregion
    }
}
