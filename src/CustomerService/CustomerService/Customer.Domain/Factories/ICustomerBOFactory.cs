using Customer.Domain.CustomerModule.BusinessObjects;

namespace Customer.Domain.Factories
{
    public interface ICustomerBOFactory
    {
        /// <summary>
        /// Create an instance of the CustomerProfileDAO.
        /// </summary>
        /// <returns></returns>
        ICustomerBO CreateCustomerProfileBO();
    }
}