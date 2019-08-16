using Customer.Client.Profile;
using Order.Customer.Profile.DataAccessObjects;

namespace Order.Customer.Factories
{
    internal class OrderCustomerDAOFactory : IOrderCustomerDAOFactory
    {
        private readonly ICustomerProfileClient _customerProfileClient;

        public OrderCustomerDAOFactory(ICustomerProfileClient customerProfileClient)
        {
            _customerProfileClient = customerProfileClient;
        }

        public ICustomerProfileDAO CreateCustomerProfileDAO()
        {
            return new CustomerProfileDAO(_customerProfileClient);
        }
    }
}
