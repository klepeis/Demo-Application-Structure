using Customer.Domain.Customer.DataAccessObjects.Models.Entities;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Customer.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace Customer.Domain.Customer.DataAccessObjects
{
    internal interface ICustomerDAO
    {
        /// <summary>
        /// Add a new Customer Profile.
        /// </summary>
        /// <param name="profileToAdd">Customer profile to add.</param>
        /// <returns>Customer Profile that was added.</returns>
        CustomerEntity AddProfile(CustomerEntity profileToAdd);

        /// <summary>
        /// Delete a Customer Profile.
        /// </summary>
        /// <param name="profileToDelete">Profile to delete</param>
        void DeleteProfile(CustomerEntity profileToDelete);

        /// <summary>
        /// Retrieve a customer profile by Id.
        /// </summary>
        /// <param name="id">Customer Profile Id</param>
        /// <returns>Customer Profile if found, NULL if no profile located.</returns>
        CustomerEntity GetProfile(long id);

        /// <summary>
        /// Update an existing profile.
        /// </summary>
        /// <param name="updatedProfile"></param>
        /// <returns></returns>
        CustomerEntity UpdateProfile(CustomerEntity updatedProfile);
    }
}