using Product.Domain.Inventory.DataAccessObjects.DataModels.Entitys;
using Product.Domain.Product.BusinessObjects.BusinessModels;
using System;

namespace Product.Domain.Product.DataAccessObjects.DataModels.Entitys
{
    internal class ProductDetailEntity
    {
        public ProductDetailEntity() { }

        public ProductDetailEntity(BusinessObjects.BusinessModels.ProductDetail productDetail)
        {
            this.CreatedDate = productDetail.CreatedDate;
            this.Description = productDetail.Description;
            this.Id = productDetail.Id;
            this.ModifiedDate = productDetail.ModifiedDate;
            this.Name = productDetail.Name;
            this.SKU = productDetail.SKU;
            this.Status = productDetail.Status;
        }

        public long Id { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public string Description { get; set;}
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        internal ProductDetail ConvertToDTO()
        {
            return new BusinessObjects.BusinessModels.ProductDetail()
            {
                CreatedDate = this.CreatedDate,
                Description = this.Description,
                Id = this.Id,
                ModifiedDate = this.ModifiedDate,
                Name = this.Name,
                SKU = this.SKU,
                Status = this.Status
            };
        }

        #region Navigational Properties

        public InventoryDetailEntity InventoryDetail { get; set; }

        #endregion
    }
}
