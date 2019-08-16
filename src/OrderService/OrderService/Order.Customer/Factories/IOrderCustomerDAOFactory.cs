using Order.Customer.Profile.DataAccessObjects;

namespace Order.Customer.Factories
{
    internal interface IOrderCustomerDAOFactory
    {
        ICustomerProfileDAO CreateCustomerProfileDAO();
    }
}