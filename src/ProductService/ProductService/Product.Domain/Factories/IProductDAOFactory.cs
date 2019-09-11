using Product.Domain.InventoryComponent.DataAccessObjects;
using Product.Domain.ProductComponent.DataAccessObjects;

namespace Product.Domain.Factories
{
    internal interface IProductDAOFactory
    {
        IInventoryDAO CreateInventoryDetailDAO();
        IProductDAO CreateProductDetailDAO();
    }
}