using Customer.Profile.BusinessObjects;

namespace Customer.Factories
{
    public interface ICustomerBOFactory
    {
        /// <summary>
        /// Create an instance of the CustomerProfileDAO.
        /// </summary>
        /// <returns></returns>
        ICustomerProfileBO CreateCustomerProfileBO();
    }
}