using Product.Domain.Inventory.BusinessObjects;
using Product.Domain.Product.BusinessObjects;

namespace Product.Domain.Factories
{
    public interface IProductBOFactory
    {
        IInventoryDetailBO CreateInventoryDetailBO();
        IProductDetailBO CreateProductDetailBO();
    }
}