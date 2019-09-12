using Product.Domain.InventoryModule.DataAccessObjects.DataModels.Entities;
using Product.Domain.ProductModule.BusinessObjects.BusinessModels;
using System;

namespace Product.Domain.ProductModule.DataAccessObjects.DataModels.Entities
{
    internal class ProductEntity
    {
        public ProductEntity() { }

        public ProductEntity(BusinessObjects.BusinessModels.Product productDetail)
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

        internal BusinessObjects.BusinessModels.Product ConvertToBusinessModel()
        {
            return new BusinessObjects.BusinessModels.Product()
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

        public InventoryEntity InventoryDetail { get; set; }

        #endregion
    }
}
