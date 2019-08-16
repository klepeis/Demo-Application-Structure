using Order.OrderDetails.BusinessObjects;

namespace Order.Factories
{
    public interface IOrderBOFactory
    {
        IOrderDetailsBO CreateOrderDetailsBO();
    }
}