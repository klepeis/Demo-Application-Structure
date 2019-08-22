using Order.Product.InventoryDetail.BusinessObjects;
using Order.Product.ProductDetail.BusinessObjects;

namespace Order.Product.Factories
{
    internal interface IOrderProductBOFactory
    {
        IInventoryDetailBO CreateInventoryDetailBO();
        IProductDetailBO CreateProductDetailBO();
    }
}