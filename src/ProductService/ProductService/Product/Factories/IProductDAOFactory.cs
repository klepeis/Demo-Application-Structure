using Product.Inventory.DataAccessObjects;
using Product.ProductDetail.DataAccessObjects;

namespace Product.Factories
{
    internal interface IProductDAOFactory
    {
        IInventoryDetailDAO CreateInventoryDetailDAO();
        IProductDetailDAO CreateProductDetailDAO();
    }
}