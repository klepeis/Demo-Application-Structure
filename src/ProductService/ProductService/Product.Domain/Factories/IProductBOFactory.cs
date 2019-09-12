using Product.Domain.InventoryModule.BusinessObjects;
using Product.Domain.ProductModule.BusinessObjects;

namespace Product.Domain.Factories
{
    public interface IProductBOFactory
    {
        IInventoryBO CreateInventoryDetailBO();
        IProducBO CreateProductDetailBO();
    }
}