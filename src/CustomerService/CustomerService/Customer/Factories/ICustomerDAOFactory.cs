using Customer.Profile.DataAccessObjects;

namespace Customer.Factories
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