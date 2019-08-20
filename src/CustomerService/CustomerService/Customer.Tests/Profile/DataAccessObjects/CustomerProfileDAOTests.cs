using Customer.Infrastructure.DbContexts;
using Customer.Profile.DataAccessObjects;
using Customer.Profile.DataAccessObjects.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Customer.Tests.Profile.DataAccessObjects
{
    [TestClass]
    public class CustomerProfileDAOTests
    {
        public void AddProfile_Success()
        {
            var contextOptions = new DbContextOptionsBuilder<CustomerDbContext>()
                .UseInMemoryDatabase(databaseName: "")
                .Options;

            CustomerProfile customerProfile = new CustomerProfile()
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

            using (var context = new CustomerDbContext(contextOptions))
            {
                ICustomerProfileDAO customerProfileDAO = new CustomerProfileDAO(context);
                customerProfileDAO.GetProfile(customerId);
            }

        }
    }
}
