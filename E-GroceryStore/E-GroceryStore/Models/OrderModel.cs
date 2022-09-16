using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_GroceryStore.Models
{
    public class OrderModel
    {
        [Key]
        public int OrderId { get; set; }
        public string GroceryName { get; set; }
        public string CustomerName { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
    }
}
