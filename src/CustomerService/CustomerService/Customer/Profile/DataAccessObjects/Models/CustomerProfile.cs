﻿namespace Customer.Profile.DataAccessObjects.Models
{
    internal class CustomerProfile
    {
        public CustomerProfile()
        {
        }

        /// <summary>
        /// Constructor used to convert a Business CustomerProfile model to a DataAccess CustomerProfile model.
        /// </summary>
        /// <param name="customerProfile">Business Model</param>
        public CustomerProfile(BusinessObjects.Models.CustomerProfile customerProfile)
        {
            this.FirstName = customerProfile.FirstName;
            this.Id = customerProfile.Id;
            this.LastName = customerProfile.LastName;
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }

        internal BusinessObjects.Models.CustomerProfile ConvertToBusinessModel()
        {
            return new BusinessObjects.Models.CustomerProfile()
            {
                CreatedDate = this.CreatedDate,
                ModifiedDate = this.ModifiedDate,
                FirstName = this.FirstName,
                Id = this.Id,
                LastName = this.LastName
            };
        }
    }
}
