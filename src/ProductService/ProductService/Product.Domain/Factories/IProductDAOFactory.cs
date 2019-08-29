using Product.Domain.Inventory.DataAccessObjects;
using Product.Domain.Product.DataAccessObjects;

namespace Product.Domain.Factories
{
    internal interface IProductDAOFactory
    {
        IInventoryDetailDAO CreateInventoryDetailDAO();
        IProductDetailDAO CreateProductDetailDAO();
    }
}