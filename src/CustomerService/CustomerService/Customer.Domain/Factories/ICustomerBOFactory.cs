using Customer.Domain.Profile.BusinessObjects;

namespace Customer.Domain.Factories
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