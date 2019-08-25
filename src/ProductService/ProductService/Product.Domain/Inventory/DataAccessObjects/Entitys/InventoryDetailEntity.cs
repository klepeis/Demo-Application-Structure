using Product.Domain.Inventory.BusinessObjects.DTOs;
using Product.Domain.ProductDetail.DataAccessObjects.Entitys;
using System;

namespace Product.Domain.Inventory.DataAccessObjects.Entitys
{
    internal class InventoryDetailEntity
    {
        public InventoryDetailEntity() { }

        public InventoryDetailEntity(InventoryDetailDTO inventoryDetail)
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

        internal InventoryDetailDTO ConvertToDTO()
        {
            return new InventoryDetailDTO()
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
