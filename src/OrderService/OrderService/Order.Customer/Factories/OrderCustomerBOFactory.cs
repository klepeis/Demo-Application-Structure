using Order.Customer.Profile.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Customer.Factories
{
    internal class OrderCustomerBOFactory : IOrderCustomerBOFactory
    {
        private readonly IOrderCustomerDAOFactory _orderCustomerDAOFactory;

        public OrderCustomerBOFactory(IOrderCustomerDAOFactory orderCustomerDAOFactory)
        {
            _orderCustomerDAOFactory = orderCustomerDAOFactory;
        }

        public ICustomerProfileBO CreateCustomerProfileBO()
        {
            return new CustomerProfileBO(_orderCustomerDAOFactory.CreateCustomerProfileDAO());
        }
    }
}
