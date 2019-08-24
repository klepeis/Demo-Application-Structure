using Customer.Domain.Profile.DataAccessObjects;

namespace Customer.Domain.Factories
{
    internal interface ICustomerDAOFactory
    {
        /// <summary>
        /// Create an instance of the CustomerProfileDAO.
        /// </summary>
        /// <returns></returns>
        ICustomerProfileDAO CreateCustomerProfileDAO();
    }
}