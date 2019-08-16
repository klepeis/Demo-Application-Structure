using Customer.Client.Profile;
using Order.Customer.Profile.DataAccessObjects.Models;
using System.Threading.Tasks;

namespace Order.Customer.Profile.DataAccessObjects
{
    internal class CustomerProfileDAO : ICustomerProfileDAO
    {
        private readonly ICustomerProfileClient _customerProfileClient;

        public CustomerProfileDAO(ICustomerProfileClient customerProfileClient)
        {
            _customerProfileClient = customerProfileClient;
        }

        public async Task<CustomerProfile> AddCustomerProfileAsync(CustomerProfile profileToAdd)
        {
            return await _customerProfileClient.AddCustomerProfileAsync<CustomerProfile>(profileToAdd);
        }

        public async Task DeleteCustomerProfileAsync(long id)
        {
            await _customerProfileClient.DeleteCustomerProfileAsync(id);
        }

        public async Task<CustomerProfile> GetCustomerProfileAsync(long id)
        {
            return await _customerProfileClient.GetCustomerProfileAsync<CustomerProfile>(id);
        }

        public async Task UpdateCustomerProfileAsync(long id, CustomerProfile updatedProfile)
        {
            await _customerProfileClient.UpdateCustomerProfileAsync(id, updatedProfile);
        }
    }
}
