using Order.Product.InventoryDetail.DataAccessObjects;
using Order.Product.ProductDetail.DataAccessObjects;

namespace Order.Product.Factories
{
    internal interface IOrderProductDAOFactory
    {
        IInventoryDetailDAO CreateInventoryDetailDAO();
        IProductDetailDAO CreateProductDetailDAO();
    }
}