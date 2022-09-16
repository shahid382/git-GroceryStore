using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_GroceryStore.Models
{
    public class RatingModel
    {
        [Key]
        public int RatingId { get; set; }
        public string GroceryName { get; set; }
        public int RatingScaleValue { get; set; }
    }
}
