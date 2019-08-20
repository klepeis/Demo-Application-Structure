using System;
using ProductDetailModels = Product.ProductDetail.DataAccessObjects.Models;

namespace Product.Inventory.DataAccessObjects.Models
{
    internal class InventoryDetail
    {
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        #region Navigational Properties

        public ProductDetailModels.ProductDetail ProductDetail { get; set; }

        #endregion
    }
}
