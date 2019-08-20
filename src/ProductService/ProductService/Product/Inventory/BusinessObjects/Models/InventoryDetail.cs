using System;

namespace Product.Inventory.BusinessObjects.Models
{
    public class InventoryDetail
    {
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
