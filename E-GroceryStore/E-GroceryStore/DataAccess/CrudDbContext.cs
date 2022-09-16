using E_GroceryStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_GroceryStore.DataAccess
{
    public class CrudDbContext : DbContext
    {
        public CrudDbContext(DbContextOptions<CrudDbContext> options) : base(options)
        {

        }
        public DbSet<OrderModel> orderModel { get; set; }
        public DbSet<RatingModel> ratingModel { get; set; }
        public DbSet<GroceryItemsModel> groceryItemsModel { get; set; }
        public DbSet<UserModel> userModel { get; set; }
    }
}
