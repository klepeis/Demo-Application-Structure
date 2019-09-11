using Microsoft.EntityFrameworkCore;
using Product.Domain.InventoryComponent.DataAccessObjects.DataModels.Entities;
using Product.Domain.Infrastructure;
using System;

namespace Product.Domain.InventoryComponent.DataAccessObjects
{
    internal class InventoryDAO : IInventoryDAO
    {
        private readonly ProductDbContext _productDbContext;

        public InventoryDAO(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext ?? throw new ArgumentNullException(nameof(productDbContext));
        }

        public InventoryEntity AddInventoryDetail(InventoryEntity itemToAdd)
        {
            _productDbContext.InventoryDetails.Add(itemToAdd);
            _productDbContext.SaveChanges();
            return itemToAdd;
        }

        public void DeleteInventoryDetail(InventoryEntity itemToDelete)
        {
            _productDbContext.InventoryDetails.Remove(itemToDelete);
            _productDbContext.SaveChanges();
        }

        public InventoryEntity GetInventoryDetail(long id)
        {
            return _productDbContext.InventoryDetails.Find(id);
        }

        public InventoryEntity UpdateInventoryDetail(InventoryEntity itemToUpdate)
        {
            _productDbContext.Entry(itemToUpdate).State = EntityState.Modified;
            _productDbContext.SaveChanges();

            return itemToUpdate;
        }
    }
}
