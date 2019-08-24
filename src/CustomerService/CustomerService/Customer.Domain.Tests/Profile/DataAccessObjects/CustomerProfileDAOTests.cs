using Customer.Domain.Infrastructure;
using Customer.Domain.Profile.DataAccessObjects;
using Customer.Domain.Profile.DataAccessObjects.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Customer.Domain.Tests.Profile.DataAccessObjects
{
    [TestClass]
    public class CustomerProfileDAOTests
    {
        #region AddProfile

        [TestMethod]
        public void AddProfile_Success()
        {
            // Arrange
            var contextOptions = new DbContextOptionsBuilder<CustomerDbContext>()
                .UseInMemoryDatabase(databaseName: "CustomerProfileDb")
                .Options;

            CustomerProfileEntity customerProfile = new CustomerProfileEntity()
            {
                FirstName = "Test",
                LastName = "User"
            };

            // Act
            long customerId;
            using (var context = new CustomerDbContext(contextOptions))
            {
                ICustomerProfileDAO customerProfileDAO = new CustomerProfileDAO(context);
                var addedProfile = customerProfileDAO.AddProfile(customerProfile);
                customerId = addedProfile.Id;
            }

            // Assert
            CustomerProfileEntity actual = null;
            using (var context = new CustomerDbContext(contextOptions))
            {
                ICustomerProfileDAO customerProfileDAO = new CustomerProfileDAO(context);
                actual = customerProfileDAO.GetProfile(customerId);
            }

            Assert.AreEqual(customerProfile.FirstName, actual.FirstName);
            Assert.AreEqual(customerProfile.LastName, actual.LastName);
        }

        #endregion

        #region DeleteProfile

        [TestMethod]
        public void DeleteProfile_Success()
        {
            // Arrange
            var contextOptions = new DbContextOptionsBuilder<CustomerDbContext>()
                .UseInMemoryDatabase(databaseName: "CustomerProfileDb")
                .Options;

            CustomerProfileEntity customerProfile = new CustomerProfileEntity()
            {
                FirstName = "Test",
                LastName = "User"
            };

            long customerId;
            using (var context = new CustomerDbContext(contextOptions))
            {
                ICustomerProfileDAO customerProfileDAO = new CustomerProfileDAO(context);
                var addedProfile = customerProfileDAO.AddProfile(customerProfile);
                customerId = addedProfile.Id;
            }

            // Act
            CustomerProfileEntity actual;
            using (var context = new CustomerDbContext(contextOptions))
            {
                ICustomerProfileDAO customerProfileDAO = new CustomerProfileDAO(context);
                CustomerProfileEntity customerProfileToDelete = customerProfileDAO.GetProfile(customerId);
                customerProfileDAO.DeleteProfile(customerProfileToDelete);

                actual = customerProfileDAO.GetProfile(customerId);
            }

            // Assert
            Assert.IsNull(actual);
        }

        #endregion

        #region GetProfile

        [TestMethod]
        public void GetProfile_Success()
        {
            // Arrange
            var contextOptions = new DbContextOptionsBuilder<CustomerDbContext>()
                .UseInMemoryDatabase(databaseName: "CustomerProfileDb")
                .Options;

            CustomerProfileEntity customerProfile = new CustomerProfileEntity()
            {
                FirstName = "Test",
                LastName = "User"
            };

            long customerId;
            using (var context = new CustomerDbContext(contextOptions))
            {
                ICustomerProfileDAO customerProfileDAO = new CustomerProfileDAO(context);
                var addedProfile = customerProfileDAO.AddProfile(customerProfile);
                customerId = addedProfile.Id;
            }

            // Act
            CustomerProfileEntity actual = null;
            using (var context = new CustomerDbContext(contextOptions))
            {
                ICustomerProfileDAO customerProfileDAO = new CustomerProfileDAO(context);
                actual = customerProfileDAO.GetProfile(customerId);
            }

            // Assert
            Assert.AreEqual(customerProfile.FirstName, actual.FirstName);
            Assert.AreEqual(customerProfile.LastName, actual.LastName);
        }

        [TestMethod]
        public void GetProfile_NotFound_ReturnNull()
        {
            // Arrange
            var contextOptions = new DbContextOptionsBuilder<CustomerDbContext>()
                .UseInMemoryDatabase(databaseName: "CustomerProfileDb")
                .Options;

            CustomerProfileEntity customerProfile = new CustomerProfileEntity()
            {
                FirstName = "Test",
                LastName = "User"
            };

            long customerId;
            using (var context = new CustomerDbContext(contextOptions))
            {
                ICustomerProfileDAO customerProfileDAO = new CustomerProfileDAO(context);
                var addedProfile = customerProfileDAO.AddProfile(customerProfile);
                customerId = addedProfile.Id;
            }

            // Act
            CustomerProfileEntity actual = null;
            using (var context = new CustomerDbContext(contextOptions))
            {
                ICustomerProfileDAO customerProfileDAO = new CustomerProfileDAO(context);
                actual = customerProfileDAO.GetProfile(customerId+1);
            }

            // Assert
            Assert.IsNull(actual);
        }

        #endregion

        #region UpdateProfile

        [TestMethod]
        public void UpdateProfile_Success()
        {
            // Arrange
            var contextOptions = new DbContextOptionsBuilder<CustomerDbContext>()
                .UseInMemoryDatabase(databaseName: "CustomerProfileDb")
                .Options;

            CustomerProfileEntity customerProfile = new CustomerProfileEntity()
            {
                FirstName = "Test",
                LastName = "User"
            };

            // Act
            long customerId;
            CustomerProfileEntity expected;
            using (var context = new CustomerDbContext(contextOptions))
            {
                ICustomerProfileDAO customerProfileDAO = new CustomerProfileDAO(context);
                var addedProfile = customerProfileDAO.AddProfile(customerProfile);
                customerId = addedProfile.Id;

                CustomerProfileEntity profileToUpdate = addedProfile;
                profileToUpdate.LastName = "Updated";

                expected = customerProfileDAO.UpdateProfile(profileToUpdate);
            }

            // Assert
            CustomerProfileEntity actual = null;
            using (var context = new CustomerDbContext(contextOptions))
            {
                ICustomerProfileDAO customerProfileDAO = new CustomerProfileDAO(context);
                actual = customerProfileDAO.GetProfile(customerId);
            }

            Assert.AreEqual(expected.CreatedDate, actual.CreatedDate);
            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.LastName, actual.LastName);
        }

        #endregion
    }
}
