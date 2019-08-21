using Order.Product.InventoryDetail.DataAccessObjects;

namespace Order.Product.Factories
{
    internal interface IOrderProductDAOFactory
    {
        IInventoryDetailDAO CreateInventoryDetailDAO();
    }
}