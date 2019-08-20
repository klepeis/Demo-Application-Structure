using System;
using ProductDetailModels = Product.ProductDetail.DataAccessObjects.Models;

namespace Product.Inventory.DataAccessObjects.Models
{
    internal class InventoryDetail
    {
        public InventoryDetail() { }

        public InventoryDetail(BusinessObjects.Models.InventoryDetail inventoryDetail)
        {
            this.CreatedDate = inventoryDetail.CreatedDate;
            this.ModifiedDate = inventoryDetail.ModifiedDate;
            this.ProductId = inventoryDetail.ProductId;
            this.Quantity = inventoryDetail.Quantity;
        }

        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        internal BusinessObjects.Models.InventoryDetail ConvertToBusinessObject()
        {
            return new BusinessObjects.Models.InventoryDetail()
            {
                CreatedDate = this.CreatedDate,
                ModifiedDate = this.ModifiedDate,
                ProductId = this.ProductId,
                Quantity = this.Quantity
            };
        }

        #region Navigational Properties

        public ProductDetailModels.ProductDetail ProductDetail { get; set; }

        #endregion
    }
}
