using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_GroceryStore.Models
{
    public class GroceryItemsModel
    {
        [Key]
        public int GroceryId { get; set; }
        public string GroceryName { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string ExpiryDate { get; set; }
    }
}
