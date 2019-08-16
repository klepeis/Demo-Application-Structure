using Order.Customer.Profile.BusinessObjects;

namespace Order.Factories
{
    internal class OrderBOFactory : IOrderBOFactory
    {
        private readonly ICustomerProfileBO _customerProfileBO;

        public OrderBOFactory(ICustomerProfileBO customerProfileBO)
        {
            _customerProfileBO = customerProfileBO;
        }


    }
}
