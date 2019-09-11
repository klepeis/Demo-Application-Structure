using Product.Domain.InventoryComponent.BusinessObjects.BusinessModels;
using Product.Domain.ProductComponent.DataAccessObjects.DataModels.Entities;
using System;

namespace Product.Domain.InventoryComponent.DataAccessObjects.DataModels.Entities
{
    internal class InventoryEntity
    {
        public InventoryEntity() { }

        public InventoryEntity(Inventory inventoryDetail)
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

        internal Inventory ConvertToBusinessModel()
        {
            return new Inventory()
            {
                CreatedDate = this.CreatedDate,
                ModifiedDate = this.ModifiedDate,
                ProductId = this.ProductId,
                Quantity = this.Quantity
            };
        }

        #region Navigational Properties

        public ProductEntity ProductDetail { get; set; }

        #endregion
    }
}
