using Customer.Client.Profile;
using Order.Customer.Infrastructure.DbContexts;
using Order.Customer.Profile.DataAccessObjects;

namespace Order.Customer.Factories
{
    internal class OrderCustomerDAOFactory : IOrderCustomerDAOFactory
    {
        private readonly CustomerDbContext _orderCustomerDbContext;
        private readonly ICustomerProfileClient _customerProfileClient;
        
        public OrderCustomerDAOFactory(CustomerDbContext orderCustomerDbContext, ICustomerProfileClient customerProfileClient)
        {
            _orderCustomerDbContext = orderCustomerDbContext;
            _customerProfileClient = customerProfileClient;
        }

        public ICustomerProfileDAO CreateCustomerProfileDAO()
        {
            return new CustomerProfileDAO(_customerProfileClient);
        }
    }
}
