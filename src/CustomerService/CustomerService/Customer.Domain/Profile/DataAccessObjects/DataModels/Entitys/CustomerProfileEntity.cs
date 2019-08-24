using Customer.Domain.Profile.BusinessObjects.DTOs;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Customer.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace Customer.Domain.Profile.DataAccessObjects.Models.Entitys
{
    internal class CustomerProfileEntity
    {
        public CustomerProfileEntity()
        {
        }

        /// <summary>
        /// Constructor used to convert a Business CustomerProfile model to a DataAccess CustomerProfile model.
        /// </summary>
        /// <param name="customerProfile">Business Model</param>
        public CustomerProfileEntity(CustomerProfileDTO customerProfile)
        {
            this.FirstName = customerProfile.FirstName;
            this.Id = customerProfile.Id;
            this.LastName = customerProfile.LastName;
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        internal CustomerProfileDTO ConvertToDTO()
        {
            return new CustomerProfileDTO()
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
