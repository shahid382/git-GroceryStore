using E_GroceryStore.Core.Interface;
using E_GroceryStore.DataAccess;
using E_GroceryStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_GroceryStore.Core.Repository
{
    public class Rating:IRating
    {
        private readonly CrudDbContext _context;
        public Rating(CrudDbContext _context)
        {
            this._context = _context;
        }
        public List<RatingModel> GetRating()
        {
            try
            {
                var result = _context.ratingModel.ToList();
                return result;
            }
            catch (Exception ex) { throw ex; }
        }
        public RatingModel AddRating(RatingModel ratingModel)
        {
            try
            {
                _context.ratingModel.AddAsync(ratingModel);
                _context.SaveChangesAsync();
                return ratingModel;
            }
            catch (Exception ex) { throw ex; }
        }
        public RatingModel UpdateRating(RatingModel ratingModel)
        {
            var result = _context.ratingModel.FirstOrDefault(x => x.RatingId == ratingModel.RatingId);
            if (result != null)
            {
                result.GroceryName = ratingModel.GroceryName;
                result.RatingScaleValue = ratingModel.RatingScaleValue;
                _context.SaveChanges();
                return result;
            }
            return null;
        }
        public RatingModel DeleteRating(int ratingId)
        {
            try
            {
                var result = _context.ratingModel.FirstOrDefault(x => x.RatingId == ratingId);
                if (result != null)
                {
                    _context.ratingModel.Remove(result);
                    _context.SaveChanges();
                }
                return result;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
