using Customer.Domain.Profile.DataAccessObjects.Models.Entity;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Customer.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace Customer.Domain.Profile.DataAccessObjects
{
    internal interface ICustomerProfileDAO
    {
        /// <summary>
        /// Add a new Customer Profile.
        /// </summary>
        /// <param name="profileToAdd">Customer profile to add.</param>
        /// <returns>Customer Profile that was added.</returns>
        CustomerProfileEntity AddProfile(CustomerProfileEntity profileToAdd);

        /// <summary>
        /// Delete a Customer Profile.
        /// </summary>
        /// <param name="profileToDelete">Profile to delete</param>
        void DeleteProfile(CustomerProfileEntity profileToDelete);

        /// <summary>
        /// Retrieve a customer profile by Id.
        /// </summary>
        /// <param name="id">Customer Profile Id</param>
        /// <returns>Customer Profile if found, NULL if no profile located.</returns>
        CustomerProfileEntity GetProfile(long id);

        /// <summary>
        /// Update an existing profile.
        /// </summary>
        /// <param name="updatedProfile"></param>
        /// <returns></returns>
        CustomerProfileEntity UpdateProfile(CustomerProfileEntity updatedProfile);
    }
}