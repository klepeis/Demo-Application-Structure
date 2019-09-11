using Customer.Domain.CustomerComponent.DataAccessObjects;
using Customer.Domain.CustomerComponent.DataAccessObjects.Models.Entities;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Customer.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace Customer.Domain.CustomerComponent.BusinessObjects
{
    internal class CustomerBO : ICustomerBO
    {
        private readonly ICustomerDAO _customerProfileDAO;

        public CustomerBO(ICustomerDAO customerProfileDAO)
        {
            _customerProfileDAO = customerProfileDAO ?? throw new ArgumentNullException(nameof(customerProfileDAO));
        }

        /// <summary>
        /// Add a new Customer Profile.
        /// </summary>
        /// <param name="profileToAdd">Customer profile to add.</param>
        /// <returns>Customer Profile that was added.</returns>
        public BusinessModels.Customer AddProfile(BusinessModels.Customer profileToAdd)
        {
            return _customerProfileDAO.AddProfile(new CustomerEntity(profileToAdd))
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
        public BusinessModels.Customer GetProfile(long id)
        {
            var result = _customerProfileDAO.GetProfile(id);

            if(result == null)
            {
                return null;
            }

            return result.ConvertToBusinessModel();
        }

        /// <summary>
        /// Update an existing profile.
        /// </summary>
        /// <param name="updatedProfile"></param>
        /// <returns></returns>
        public BusinessModels.Customer UpdateProfile(BusinessModels.Customer updatedProfile)
        {
            return _customerProfileDAO.UpdateProfile(new CustomerEntity(updatedProfile))
                                      .ConvertToBusinessModel();
        }
    }
}
