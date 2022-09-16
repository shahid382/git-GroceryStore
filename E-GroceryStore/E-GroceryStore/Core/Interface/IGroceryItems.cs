using E_GroceryStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_GroceryStore.Core.Interface
{
    public interface IGroceryItems
    {
        List<GroceryItemsModel> GetGroceryItems();
        GroceryItemsModel AddGrocery(GroceryItemsModel groceryItemsModel);
        GroceryItemsModel UpdateGrocery(GroceryItemsModel groceryItemsModel);
        GroceryItemsModel DeleteGrocery(int groceryId);
    }
}
