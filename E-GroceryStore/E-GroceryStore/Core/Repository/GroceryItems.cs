using E_GroceryStore.Core.Interface;
using E_GroceryStore.DataAccess;
using E_GroceryStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_GroceryStore.Core.Repository
{
    public class GroceryItems : IGroceryItems
    {
        private readonly CrudDbContext _context;
        public GroceryItems(CrudDbContext _context)
        {
            this._context = _context;
        }
        public List<GroceryItemsModel> GetGroceryItems()
        {
            try
            {
                var result = _context.groceryItemsModel.ToList();
                return result;
            }
            catch (Exception ex) { throw ex; }
        }
        public List<GroceryItemsModel> Search(string groceryName)
        {

            try
            {
                IQueryable<GroceryItemsModel> query= _context.groceryItemsModel;
                if (!string.IsNullOrEmpty(groceryName))
                {
                    query = query.Where(e => e.GroceryName == groceryName);
                }
                return query.ToList();
            }
            catch (Exception ex) { throw ex; }
        }
        public GroceryItemsModel AddGrocery(GroceryItemsModel groceryItemsModel)
        {
            try
            {
                _context.groceryItemsModel.AddAsync(groceryItemsModel);
                _context.SaveChangesAsync();
                return groceryItemsModel;
            }
            catch (Exception ex) { throw ex; }
        }
        public GroceryItemsModel UpdateGrocery(GroceryItemsModel groceryItemsModel)
        {
            var result = _context.groceryItemsModel.FirstOrDefault(x => x.GroceryId == groceryItemsModel.GroceryId);
            if (result != null)
            {
                result.GroceryName = groceryItemsModel.GroceryName;
                result.Price = groceryItemsModel.Price;
                result.ExpiryDate = groceryItemsModel.ExpiryDate;
                _context.SaveChanges();
                return result;
            }
            return null;
        }
        public GroceryItemsModel DeleteGrocery(int groceryId)
        {
            try
            {
                var result = _context.groceryItemsModel.FirstOrDefault(x => x.GroceryId == groceryId);
                if (result != null)
                {
                    _context.groceryItemsModel.Remove(result);
                    _context.SaveChanges();
                }
                return result;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
