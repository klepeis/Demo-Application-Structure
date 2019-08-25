using Customer.API.Controllers;
using Customer.Domain.Profile.BusinessObjects;
using Customer.Domain.Profile.BusinessObjects.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Net;

namespace Customer.API.UnitTests.Controllers
{
    [TestClass]
    public class ProfileControllerTests
    {
        #region ProfileController

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ProfileController_Instantiation_ConstructorParameterNull_ThrowArgumentNullException()
        {
            // Arrange
            ICustomerProfileBO customerProfileBO = null;

            // Act
            ProfileController controller = new ProfileController(customerProfileBO);

            // Assert
            // Assertion is done via ExpectedException attribute.
        }

        #endregion

        #region GetCustomerProfile

        [TestMethod]
        public void GetCustomerProfile_Success200Ok()
        {
            // Arrange
            CustomerProfileDTO expectedContent = new CustomerProfileDTO()
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
            ActionResult<CustomerProfileDTO> response = controller.GetCustomerProfile(It.IsAny<long>());

            // Assert
            var actualStatusCode = (response.Result as ObjectResult).StatusCode;
            Assert.AreEqual((int)HttpStatusCode.OK, actualStatusCode);

            var actualContent = (CustomerProfileDTO)Convert.ChangeType((response.Result as ObjectResult)?.Value, typeof(CustomerProfileDTO));
            Assert.AreEqual(expectedContent, actualContent);
        }

        #endregion

        #region AddCustomerProfile_Success201

        [TestMethod]
        public void AddCustomerProfile_Success201Created()
        {

            // Arrange
            CustomerProfileDTO expectedContent = new CustomerProfileDTO()
            {
                CreatedDate = DateTime.Now,
                FirstName = "Test",
                Id = 123,
                LastName = "User",
                ModifiedDate = DateTime.Now
            };

            Mock<ICustomerProfileBO> mockCustomerProfileBO = new Mock<ICustomerProfileBO>();
            mockCustomerProfileBO.Setup(m => m.AddProfile(It.IsAny<CustomerProfileDTO>()))
                .Returns(expectedContent);

            // Act
            ProfileController controller = new ProfileController(mockCustomerProfileBO.Object);
            ActionResult<CustomerProfileDTO> response = controller.AddCustomerProfile(new CustomerProfileDTO
            {
                FirstName = "Test",
                LastName = "User"
            });

            // Assert
            var actualStatusCode = (response.Result as ObjectResult).StatusCode;
            Assert.AreEqual((int)HttpStatusCode.Created, actualStatusCode);

            var actualContent = (CustomerProfileDTO)Convert.ChangeType((response.Result as ObjectResult)?.Value, typeof(CustomerProfileDTO));
            Assert.AreEqual(expectedContent, actualContent);
        }

        #endregion

        #region UpdateCustomerProfile

        [TestMethod]
        public void UpdateCustomerProfile_Success204NoContent()
        {
            // Arrange
            CustomerProfileDTO expectedContent = new CustomerProfileDTO()
            {
                CreatedDate = DateTime.Now,
                FirstName = "Test",
                Id = 123,
                LastName = "User",
                ModifiedDate = DateTime.Now
            };

            Mock<ICustomerProfileBO> mockCustomerProfileBO = new Mock<ICustomerProfileBO>();
            mockCustomerProfileBO.Setup(m => m.UpdateProfile(It.IsAny<CustomerProfileDTO>()))
                .Returns(expectedContent);

            // Act
            ProfileController controller = new ProfileController(mockCustomerProfileBO.Object);
            ActionResult response = controller.UpdateCustomerProfile(123, new CustomerProfileDTO()
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
            CustomerProfileDTO expectedContent = new CustomerProfileDTO()
            {
                CreatedDate = DateTime.Now,
                FirstName = "Test",
                Id = 123,
                LastName = "User",
                ModifiedDate = DateTime.Now
            };

            Mock<ICustomerProfileBO> mockCustomerProfileBO = new Mock<ICustomerProfileBO>();
            mockCustomerProfileBO.Setup(m => m.UpdateProfile(It.IsAny<CustomerProfileDTO>()))
                .Returns(expectedContent);

            // Act
            ProfileController controller = new ProfileController(mockCustomerProfileBO.Object);
            ActionResult response = controller.UpdateCustomerProfile(123, new CustomerProfileDTO()
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
