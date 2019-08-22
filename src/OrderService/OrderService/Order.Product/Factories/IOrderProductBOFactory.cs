using Order.Product.InventoryDetail.BusinessObjects;
using Order.Product.ProductDetail.BusinessObjects;

namespace Order.Product.Factories
{
    public interface IOrderProductBOFactory
    {
        IInventoryDetailBO CreateInventoryDetailBO();
        IProductDetailBO CreateProductDetailBO();
    }
}