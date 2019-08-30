using Microsoft.EntityFrameworkCore;
using Product.Domain.Inventory.DataAccessObjects.DataModels.Entitys;
using Product.Domain.Infrastructure;
using System;

namespace Product.Domain.Inventory.DataAccessObjects
{
    internal class InventoryDetailDAO : IInventoryDetailDAO
    {
        private readonly ProductDbContext _productDbContext;

        public InventoryDetailDAO(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext ?? throw new ArgumentNullException(nameof(productDbContext));
        }

        public InventoryDetailEntity AddInventoryDetail(InventoryDetailEntity itemToAdd)
        {
            _productDbContext.InventoryDetails.Add(itemToAdd);
            _productDbContext.SaveChanges();
            return itemToAdd;
        }

        public void DeleteInventoryDetail(InventoryDetailEntity itemToDelete)
        {
            _productDbContext.InventoryDetails.Remove(itemToDelete);
            _productDbContext.SaveChanges();
        }

        public InventoryDetailEntity GetInventoryDetail(long id)
        {
            return _productDbContext.InventoryDetails.Find(id);
        }

        public InventoryDetailEntity UpdateInventoryDetail(InventoryDetailEntity itemToUpdate)
        {
            _productDbContext.Entry(itemToUpdate).State = EntityState.Modified;
            _productDbContext.SaveChanges();

            return itemToUpdate;
        }
    }
}
