using Customer.Domain.Infrastructure;
using Customer.Domain.Customer.DataAccessObjects;
using System;

namespace Customer.Domain.Factories
{
    internal class CustomerDAOFactory : ICustomerDAOFactory
    {
        private readonly CustomerDbContext _customerDbContext;

        public CustomerDAOFactory(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext ?? throw new ArgumentNullException(nameof(customerDbContext));
        }

        /// <summary>
        /// Create an instance of the CustomerProfileDAO.
        /// </summary>
        /// <returns></returns>
        public ICustomerDAO CreateCustomerProfileDAO()
        {
            return new CustomerDAO(_customerDbContext);
        }
    }
}
