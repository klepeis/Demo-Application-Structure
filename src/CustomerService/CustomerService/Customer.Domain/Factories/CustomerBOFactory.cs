using Customer.Domain.Profile.BusinessObjects;

namespace Customer.Domain.Factories
{
    internal class CustomerBOFactory : ICustomerBOFactory
    {
        private readonly ICustomerDAOFactory _customerDAOFactory;

        public CustomerBOFactory(ICustomerDAOFactory customerDAOFactory)
        {
            _customerDAOFactory = customerDAOFactory;
        }

        /// <summary>
        /// Create an instance of the CustomerProfileBO.
        /// </summary>
        /// <returns></returns>
        public ICustomerProfileBO CreateCustomerProfileBO()
        {
            return new CustomerProfileBO(_customerDAOFactory.CreateCustomerProfileDAO());
        }
    }
}
