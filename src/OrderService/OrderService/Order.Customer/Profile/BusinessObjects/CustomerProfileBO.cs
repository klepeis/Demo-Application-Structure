using Order.Customer.Profile.DataAccessObjects;

namespace Order.Customer.Profile.BusinessObjects
{
    internal class CustomerProfileBO : ICustomerProfileBO
    {
        private readonly ICustomerProfileDAO _customerProfileDAO;

        public CustomerProfileBO(ICustomerProfileDAO customerProfileDAO)
        {
            _customerProfileDAO = customerProfileDAO;
        }
    }
}
