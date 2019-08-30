using Product.Domain.Inventory.BusinessObjects.BusinessModels;
using Product.Domain.Product.DataAccessObjects.DataModels.Entitys;
using System;

namespace Product.Domain.Inventory.DataAccessObjects.DataModels.Entitys
{
    internal class InventoryDetailEntity
    {
        public InventoryDetailEntity() { }

        public InventoryDetailEntity(InventoryDetail inventoryDetail)
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

        internal InventoryDetail ConvertToDTO()
        {
            return new InventoryDetail()
            {
                CreatedDate = this.CreatedDate,
                ModifiedDate = this.ModifiedDate,
                ProductId = this.ProductId,
                Quantity = this.Quantity
            };
        }

        #region Navigational Properties

        public ProductDetailEntity ProductDetail { get; set; }

        #endregion
    }
}
