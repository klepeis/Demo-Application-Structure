using Product.Inventory.DataAccessObjects.Models;
using System;

namespace Product.ProductDetail.DataAccessObjects.Models
{
    internal class ProductDetail
    {
        public ProductDetail() { }

        public ProductDetail(BusinessObjects.Models.ProductDetail productDetail)
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

        internal BusinessObjects.Models.ProductDetail ConvertToBusinessObject()
        {
            return new BusinessObjects.Models.ProductDetail()
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

        public InventoryDetail InventoryDetail { get; set; }

        #endregion
    }
}
