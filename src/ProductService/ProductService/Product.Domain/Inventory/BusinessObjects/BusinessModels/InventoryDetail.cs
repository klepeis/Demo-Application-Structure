using System;

namespace Product.Domain.Inventory.BusinessObjects.BusinessModels
{
    public class InventoryDetail
    {
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
