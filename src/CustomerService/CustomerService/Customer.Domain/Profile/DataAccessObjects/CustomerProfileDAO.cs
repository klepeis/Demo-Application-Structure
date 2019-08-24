using Customer.Domain.Infrastructure;
using Customer.Domain.Profile.DataAccessObjects.Models.Entitys;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Customer.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace Customer.Domain.Profile.DataAccessObjects
{
    internal class CustomerProfileDAO : ICustomerProfileDAO
    {
        private readonly CustomerDbContext _customerDbContext;

        public CustomerProfileDAO(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }

        /// <summary>
        /// Add a new Customer Profile.
        /// </summary>
        /// <param name="profileToAdd">Customer profile to add.</param>
        /// <returns>Customer Profile that was added.</returns>
        public CustomerProfileEntity AddProfile(CustomerProfileEntity profileToAdd)
        {
            _customerDbContext.CustomerProfiles.Add(profileToAdd);
            _customerDbContext.SaveChanges();
            return profileToAdd;
        }

        /// <summary>
        /// Delete a Customer Profile.
        /// </summary>
        /// <param name="profileToDelete">Profile to delete</param>
        public void DeleteProfile(CustomerProfileEntity profileToDelete)
        {
            _customerDbContext.CustomerProfiles.Remove(profileToDelete);
            _customerDbContext.SaveChanges();
        }

        /// <summary>
        /// Retrieve a customer profile by Id.
        /// </summary>
        /// <param name="id">Customer Profile Id</param>
        /// <returns>Customer Profile if found, NULL if no profile located.</returns>
        public CustomerProfileEntity GetProfile(long id)
        {
            return _customerDbContext.CustomerProfiles.Find(id);
        }

        /// <summary>
        /// Update an existing profile.
        /// </summary>
        /// <param name="updatedProfile"></param>
        /// <returns></returns>
        public CustomerProfileEntity UpdateProfile(CustomerProfileEntity updatedProfile)
        {
            _customerDbContext.Entry(updatedProfile).State = EntityState.Modified;
            _customerDbContext.SaveChanges();

            return updatedProfile;
        }
    }
}
