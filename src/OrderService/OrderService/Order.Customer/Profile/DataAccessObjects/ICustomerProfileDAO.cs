using Order.Customer.Profile.DataAccessObjects.Models;
using System.Threading.Tasks;

namespace Order.Customer.Profile.DataAccessObjects
{
    internal interface ICustomerProfileDAO
    {
        Task<CustomerProfile> AddCustomerProfileAsync(CustomerProfile profileToAdd);
        Task DeleteCustomerProfileAsync(long id);
        Task<CustomerProfile> GetCustomerProfileAsync(long id);
        Task UpdateCustomerProfileAsync(long id, CustomerProfile updatedProfile);
    }
}