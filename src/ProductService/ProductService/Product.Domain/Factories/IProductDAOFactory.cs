using Product.Domain.InventoryModule.DataAccessObjects;
using Product.Domain.ProductModule.DataAccessObjects;

namespace Product.Domain.Factories
{
    internal interface IProductDAOFactory
    {
        IInventoryDAO CreateInventoryDetailDAO();
        IProductDAO CreateProductDetailDAO();
    }
}