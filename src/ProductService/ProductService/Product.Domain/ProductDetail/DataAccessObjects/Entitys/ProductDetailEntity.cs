﻿using Product.Domain.Inventory.DataAccessObjects.Entitys;
using Product.Domain.ProductDetail.BusinessObjects.DTOs;
using System;

namespace Product.Domain.ProductDetail.DataAccessObjects.Entitys
{
    internal class ProductDetailEntity
    {
        public ProductDetailEntity() { }

        public ProductDetailEntity(ProductDetailDTO productDetail)
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

        internal ProductDetailDTO ConvertToDTO()
        {
            return new ProductDetailDTO()
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