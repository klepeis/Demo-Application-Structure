using System;

namespace Product.Domain.InventoryModule.BusinessObjects.BusinessModels
{
    public class Inventory
    {
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
