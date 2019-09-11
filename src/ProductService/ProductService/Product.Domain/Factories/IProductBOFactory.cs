using Product.Domain.InventoryComponent.BusinessObjects;
using Product.Domain.ProductComponent.BusinessObjects;

namespace Product.Domain.Factories
{
    public interface IProductBOFactory
    {
        IInventoryBO CreateInventoryDetailBO();
        IProducBO CreateProductDetailBO();
    }
}