using Product.Domain.Inventory.BusinessObjects;
using Product.Domain.ProductDetail.BusinessObjects;

namespace Product.Domain.Factories
{
    public interface IProductBOFactory
    {
        IInventoryDetailBO CreateInventoryDetailBO();
        IProductDetailBO CreateProductDetailBO();
    }
}