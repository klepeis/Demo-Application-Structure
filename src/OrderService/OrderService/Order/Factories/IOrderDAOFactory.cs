using Order.OrderDetails.DataAccessObjects;

namespace Order.Factories
{
    internal interface IOrderDAOFactory
    {
        IOrderDetailsDAO CreateOrderDetailsDAO();
    }
}