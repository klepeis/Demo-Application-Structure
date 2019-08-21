using Order.Product.InventoryDetail.BusinessObjects;

namespace Order.Product.Factories
{
    internal interface IOrderProductBOFactory
    {
        IInventoryDetailBO CreateInventoryDetailBO();
    }
}