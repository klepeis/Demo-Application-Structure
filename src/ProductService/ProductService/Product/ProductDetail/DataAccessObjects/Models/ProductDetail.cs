using Product.Inventory.DataAccessObjects.Models;
using System;

namespace Product.ProductDetail.DataAccessObjects.Models
{
    internal class ProductDetail
    {
        public long Id { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public string Description { get; set;}
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        #region Navigational Properties

        public InventoryDetail InventoryDetail { get; set; }

        #endregion
    }
}
