using Customer.Profile.BusinessObjects.Models;
using Customer.Profile.DataAccessObjects;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Customer.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace Customer.Profile.BusinessObjects
{
    internal class CustomerProfileBO : ICustomerProfileBO
    {
        private readonly ICustomerProfileDAO _customerProfileDAO;

        public CustomerProfileBO(ICustomerProfileDAO customerProfileDAO)
        {
            _customerProfileDAO = customerProfileDAO;
        }

        /// <summary>
        /// Add a new Customer Profile.
        /// </summary>
        /// <param name="profileToAdd">Customer profile to add.</param>
        /// <returns>Customer Profile that was added.</returns>
        public CustomerProfile AddProfile(CustomerProfile profileToAdd)
        {
            return _customerProfileDAO.AddProfile(new DataAccessObjects.Models.CustomerProfile(profileToAdd))
                                      .ConvertToBusinessModel();
        }

        /// <summary>
        /// Delete a Customer Profile.
        /// </summary>
        /// <param name="id">Customer Profile Id</param>
        public void DeleteProfile(long id)
        {
            var profileToDelete = _customerProfileDAO.GetProfile(id);

            if(profileToDelete == null)
            {
                //Handle Profile Not Found.
            }

            _customerProfileDAO.DeleteProfile(profileToDelete);
        }

        /// <summary>
        /// Retrieve a customer profile by Id.
        /// </summary>
        /// <param name="id">Customer Profile Id</param>
        /// <returns>Customer Profile if found, NULL if no profile located.</returns>
        public CustomerProfile GetProfile(long id)
        {
            return _customerProfileDAO.GetProfile(id)
                                      .ConvertToBusinessModel();
        }

        /// <summary>
        /// Update an existing profile.
        /// </summary>
        /// <param name="updatedProfile"></param>
        /// <returns></returns>
        public CustomerProfile UpdateProfile(CustomerProfile updatedProfile)
        {
            return _customerProfileDAO.UpdateProfile(new DataAccessObjects.Models.CustomerProfile(updatedProfile))
                                      .ConvertToBusinessModel();
        }
    }
}
