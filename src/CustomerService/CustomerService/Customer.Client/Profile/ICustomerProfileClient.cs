using Customer.Client.Profile.Models;
using System.Threading.Tasks;

namespace Customer.Client.Profile
{
    public interface ICustomerProfileClient
    {
        Task<CustomerProfile> GetCustomerProfileAsync(long id);
    }
}