using Customer.API.Controllers;
using Customer.Domain.Customer.BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Net;
using BusinessModels = Customer.Domain.Customer.BusinessObjects.BusinessModels;

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
            ICustomerBO customerProfileBO = null;

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
            Domain.Customer.BusinessObjects.BusinessModels.Customer expectedContent = new Domain.Customer.BusinessObjects.BusinessModels.Customer()
            {
                CreatedDate = DateTime.Now,
                FirstName = "Test",
                Id = 123,
                LastName = "User",
                ModifiedDate = DateTime.Now
            };

            Mock<ICustomerBO> mockCustomerProfileBO = new Mock<ICustomerBO>();
            mockCustomerProfileBO.Setup(m => m.GetProfile(It.IsAny<long>()))
                .Returns(expectedContent);

            // Act
            ProfileController controller = new ProfileController(mockCustomerProfileBO.Object);
            ActionResult<Domain.Customer.BusinessObjects.BusinessModels.Customer> response = controller.GetCustomerProfile(It.IsAny<long>());

            // Assert
            var actualStatusCode = (response.Result as ObjectResult).StatusCode;
            Assert.AreEqual((int)HttpStatusCode.OK, actualStatusCode);

            var actualContent = (Domain.Customer.BusinessObjects.BusinessModels.Customer)Convert.ChangeType((response.Result as ObjectResult)?.Value, typeof(Domain.Customer.BusinessObjects.BusinessModels.Customer));
            Assert.AreEqual(expectedContent, actualContent);
        }

        #endregion

        #region AddCustomerProfile_Success201

        [TestMethod]
        public void AddCustomerProfile_Success201Created()
        {

            // Arrange
            BusinessModels.Customer expectedContent = new BusinessModels.Customer()
            {
                CreatedDate = DateTime.Now,
                FirstName = "Test",
                Id = 123,
                LastName = "User",
                ModifiedDate = DateTime.Now
            };

            Mock<ICustomerBO> mockCustomerProfileBO = new Mock<ICustomerBO>();
            mockCustomerProfileBO.Setup(m => m.AddProfile(It.IsAny<BusinessModels.Customer>()))
                .Returns(expectedContent);

            // Act
            ProfileController controller = new ProfileController(mockCustomerProfileBO.Object);
            ActionResult<BusinessModels.Customer> response = controller.AddCustomerProfile(new BusinessModels.Customer
            {
                FirstName = "Test",
                LastName = "User"
            });

            // Assert
            var actualStatusCode = (response.Result as ObjectResult).StatusCode;
            Assert.AreEqual((int)HttpStatusCode.Created, actualStatusCode);

            var actualContent = (BusinessModels.Customer)Convert.ChangeType((response.Result as ObjectResult)?.Value, typeof(BusinessModels.Customer));
            Assert.AreEqual(expectedContent, actualContent);
        }

        #endregion

        #region UpdateCustomerProfile

        [TestMethod]
        public void UpdateCustomerProfile_Success204NoContent()
        {
            // Arrange
            BusinessModels.Customer expectedContent = new BusinessModels.Customer()
            {
                CreatedDate = DateTime.Now,
                FirstName = "Test",
                Id = 123,
                LastName = "User",
                ModifiedDate = DateTime.Now
            };

            Mock<ICustomerBO> mockCustomerProfileBO = new Mock<ICustomerBO>();
            mockCustomerProfileBO.Setup(m => m.UpdateProfile(It.IsAny<BusinessModels.Customer>()))
                .Returns(expectedContent);

            // Act
            ProfileController controller = new ProfileController(mockCustomerProfileBO.Object);
            ActionResult response = controller.UpdateCustomerProfile(123, new BusinessModels.Customer()
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
            BusinessModels.Customer expectedContent = new BusinessModels.Customer()
            {
                CreatedDate = DateTime.Now,
                FirstName = "Test",
                Id = 123,
                LastName = "User",
                ModifiedDate = DateTime.Now
            };

            Mock<ICustomerBO> mockCustomerProfileBO = new Mock<ICustomerBO>();
            mockCustomerProfileBO.Setup(m => m.UpdateProfile(It.IsAny<BusinessModels.Customer>()))
                .Returns(expectedContent);

            // Act
            ProfileController controller = new ProfileController(mockCustomerProfileBO.Object);
            ActionResult response = controller.UpdateCustomerProfile(123, new BusinessModels.Customer()
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
            Mock<ICustomerBO> mockCustomerProfileBO = new Mock<ICustomerBO>();
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
