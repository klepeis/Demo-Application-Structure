using Customer.Infrastructure.DbContexts;
using Customer.Profile.DataAccessObjects;

namespace Customer.Factories
{
    internal class CustomerDAOFactory : ICustomerDAOFactory
    {
        private readonly CustomerDbContext _customerDbContext;

        public CustomerDAOFactory(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }

        /// <summary>
        /// Create an instance of the CustomerProfileDAO.
        /// </summary>
        /// <returns></returns>
        public ICustomerProfileDAO CreateCustomerProfileDAO()
        {
            return new CustomerProfileDAO(_customerDbContext);
        }
    }
}
