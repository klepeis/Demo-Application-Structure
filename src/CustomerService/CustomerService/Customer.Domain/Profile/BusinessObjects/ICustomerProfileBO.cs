﻿using Customer.Domain.Profile.BusinessObjects.DTOs;

namespace Customer.Domain.Profile.BusinessObjects
{
    public interface ICustomerProfileBO
    {
        /// <summary>
        /// Add a new Customer Profile.
        /// </summary>
        /// <param name="profileToAdd">Customer profile to add.</param>
        /// <returns>Customer Profile that was added.</returns>
        CustomerProfileDTO AddProfile(CustomerProfileDTO profileToAdd);

        /// <summary>
        /// Delete a Customer Profile.
        /// </summary>
        /// <param name="id">Customer Profile Id</param>
        void DeleteProfile(long id);

        /// <summary>
        /// Retrieve a customer profile by Id.
        /// </summary>
        /// <param name="id">Customer Profile Id</param>
        /// <returns>Customer Profile if found, NULL if no profile located.</returns>
        CustomerProfileDTO GetProfile(long id);

        /// <summary>
        /// Update an existing profile.
        /// </summary>
        /// <param name="updatedProfile"></param>
        /// <returns></returns>
        CustomerProfileDTO UpdateProfile(CustomerProfileDTO updatedProfile);
    }
}