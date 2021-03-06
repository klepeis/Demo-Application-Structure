﻿using Customer.Domain.CustomerModule.BusinessObjects;
using System;

namespace Customer.Domain.Factories
{
    internal class CustomerBOFactory : ICustomerBOFactory
    {
        private readonly ICustomerDAOFactory _customerDAOFactory;

        public CustomerBOFactory(ICustomerDAOFactory customerDAOFactory)
        {
            _customerDAOFactory = customerDAOFactory ?? throw new ArgumentNullException(nameof(customerDAOFactory));
        }

        /// <summary>
        /// Create an instance of the CustomerProfileBO.
        /// </summary>
        /// <returns></returns>
        public ICustomerBO CreateCustomerProfileBO()
        {
            return new CustomerBO(_customerDAOFactory.CreateCustomerProfileDAO());
        }
    }
}
