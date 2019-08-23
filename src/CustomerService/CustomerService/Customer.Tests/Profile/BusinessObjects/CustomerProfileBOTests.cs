using Customer.Infrastructure.DbContexts;
using Customer.Profile.BusinessObjects;
using Customer.Profile.BusinessObjects.Models;
using Customer.Profile.DataAccessObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Customer.Tests.Profile.BusinessObjects
{
    [TestClass]
    public class CustomerProfileBOTests
    {
        #region AddProfile

        [TestMethod]
        public void AddProfile_Success()
        {
            // Arrange
            Customer.Profile.DataAccessObjects.Models.CustomerProfile seedData = new Customer.Profile.DataAccessObjects.Models.CustomerProfile()
            {
                CreatedDate = DateTime.Now,
                FirstName = "Test",
                Id = 123,
                LastName = "User",
                ModifiedDate = DateTime.Now
            };

            Mock<ICustomerProfileDAO> mockCustomerProfileDAO = new Mock<ICustomerProfileDAO>();
            mockCustomerProfileDAO.Setup(m => m.AddProfile(It.IsAny<Customer.Profile.DataAccessObjects.Models.CustomerProfile>()))
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
            mockCustomerProfileDAO.Setup(m => m.DeleteProfile(It.IsAny<Customer.Profile.DataAccessObjects.Models.CustomerProfile>()))
                .Verifiable();

            // Act
            CustomerProfileBO customerProfileBO = new CustomerProfileBO(mockCustomerProfileDAO.Object);
            customerProfileBO.DeleteProfile(123);

            // Assert
            mockCustomerProfileDAO.Verify(m => m.DeleteProfile(It.IsAny<Customer.Profile.DataAccessObjects.Models.CustomerProfile>()), Times.Once());
        }

        #endregion

        //#region GetProfile

        //[TestMethod]
        //public void GetProfile_Success()
        //{
        //    // Arrange
        //    var contextOptions = new DbContextOptionsBuilder<CustomerDbContext>()
        //        .UseInMemoryDatabase(databaseName: "CustomerProfileDb")
        //        .Options;

        //    CustomerProfile customerProfile = new CustomerProfile()
        //    {
        //        FirstName = "Test",
        //        LastName = "User"
        //    };

        //    long customerId;
        //    using (var context = new CustomerDbContext(contextOptions))
        //    {
        //        ICustomerProfileDAO customerProfileDAO = new CustomerProfileDAO(context);
        //        var addedProfile = customerProfileDAO.AddProfile(customerProfile);
        //        customerId = addedProfile.Id;
        //    }

        //    // Act
        //    CustomerProfile actual = null;
        //    using (var context = new CustomerDbContext(contextOptions))
        //    {
        //        ICustomerProfileDAO customerProfileDAO = new CustomerProfileDAO(context);
        //        actual = customerProfileDAO.GetProfile(customerId);
        //    }

        //    // Assert
        //    Assert.AreEqual(customerProfile.FirstName, actual.FirstName);
        //    Assert.AreEqual(customerProfile.LastName, actual.LastName);
        //}

        //[TestMethod]
        //public void GetProfile_NotFound_ReturnNull()
        //{
        //    // Arrange
        //    var contextOptions = new DbContextOptionsBuilder<CustomerDbContext>()
        //        .UseInMemoryDatabase(databaseName: "CustomerProfileDb")
        //        .Options;

        //    CustomerProfile customerProfile = new CustomerProfile()
        //    {
        //        FirstName = "Test",
        //        LastName = "User"
        //    };

        //    long customerId;
        //    using (var context = new CustomerDbContext(contextOptions))
        //    {
        //        ICustomerProfileDAO customerProfileDAO = new CustomerProfileDAO(context);
        //        var addedProfile = customerProfileDAO.AddProfile(customerProfile);
        //        customerId = addedProfile.Id;
        //    }

        //    // Act
        //    CustomerProfile actual = null;
        //    using (var context = new CustomerDbContext(contextOptions))
        //    {
        //        ICustomerProfileDAO customerProfileDAO = new CustomerProfileDAO(context);
        //        actual = customerProfileDAO.GetProfile(customerId + 1);
        //    }

        //    // Assert
        //    Assert.IsNull(actual);
        //}

        //#endregion

        //#region UpdateProfile

        //[TestMethod]
        //public void UpdateProfile_Success()
        //{
        //    // Arrange
        //    var contextOptions = new DbContextOptionsBuilder<CustomerDbContext>()
        //        .UseInMemoryDatabase(databaseName: "CustomerProfileDb")
        //        .Options;

        //    CustomerProfile customerProfile = new CustomerProfile()
        //    {
        //        FirstName = "Test",
        //        LastName = "User"
        //    };

        //    // Act
        //    long customerId;
        //    CustomerProfile expected;
        //    using (var context = new CustomerDbContext(contextOptions))
        //    {
        //        ICustomerProfileDAO customerProfileDAO = new CustomerProfileDAO(context);
        //        var addedProfile = customerProfileDAO.AddProfile(customerProfile);
        //        customerId = addedProfile.Id;

        //        CustomerProfile profileToUpdate = addedProfile;
        //        profileToUpdate.LastName = "Updated";

        //        expected = customerProfileDAO.UpdateProfile(profileToUpdate);
        //    }

        //    // Assert
        //    CustomerProfile actual = null;
        //    using (var context = new CustomerDbContext(contextOptions))
        //    {
        //        ICustomerProfileDAO customerProfileDAO = new CustomerProfileDAO(context);
        //        actual = customerProfileDAO.GetProfile(customerId);
        //    }

        //    Assert.AreEqual(expected.CreatedDate, actual.CreatedDate);
        //    Assert.AreEqual(expected.FirstName, actual.FirstName);
        //    Assert.AreEqual(expected.Id, actual.Id);
        //    Assert.AreEqual(expected.LastName, actual.LastName);
        //}

        //#endregion
    }
}
