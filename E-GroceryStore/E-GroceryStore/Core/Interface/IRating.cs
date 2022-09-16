using E_GroceryStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_GroceryStore.Core.Interface
{
    public interface IRating
    {
        List<RatingModel> GetRating();
        RatingModel AddRating(RatingModel ratingModel);
        RatingModel UpdateRating(RatingModel ratingModel);
        RatingModel DeleteRating(int ratingId);
    }
}
