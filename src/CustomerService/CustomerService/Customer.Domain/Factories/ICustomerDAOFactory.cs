using Customer.Domain.Customer.DataAccessObjects;

namespace Customer.Domain.Factories
{
    internal interface ICustomerDAOFactory
    {
        /// <summary>
        /// Create an instance of the CustomerProfileDAO.
        /// </summary>
        /// <returns></returns>
        ICustomerDAO CreateCustomerProfileDAO();
    }
}