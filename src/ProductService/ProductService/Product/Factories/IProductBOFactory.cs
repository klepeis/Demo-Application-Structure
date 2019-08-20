using Product.Inventory.BusinessObjects;
using Product.ProductDetail.BusinessObjects;

namespace Product.Factories
{
    public interface IProductBOFactory
    {
        IInventoryDetailBO CreateInventoryDetailBO();
        IProductDetailBO CreateProductDetailBO();
    }
}