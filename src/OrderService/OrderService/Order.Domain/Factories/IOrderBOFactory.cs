using Order.Domain.OrderDetails.BusinessObjects;

namespace Order.Domain.Factories
{
    public interface IOrderBOFactory
    {
        IOrderDetailsBO CreateOrderDetailsBO();
    }
}