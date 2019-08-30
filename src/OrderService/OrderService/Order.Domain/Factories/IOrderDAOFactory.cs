using Order.Domain.OrderDetails.DataAccessObjects;

namespace Order.Domain.Factories
{
    internal interface IOrderDAOFactory
    {
        IOrderDetailsDAO CreateOrderDetailsDAO();
    }
}