using Order.Customer.Profile.BusinessObjects;

namespace Order.Customer.Factories
{
    internal interface IOrderCustomerBOFactory
    {
        ICustomerProfileBO CreateCustomerProfileBO();
    }
}