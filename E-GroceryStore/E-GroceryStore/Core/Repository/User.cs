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
    public class User : IUser
    {
        private readonly CrudDbContext userDbContext;
        public User(CrudDbContext userDbContext)
        {
            this.userDbContext = userDbContext;
        }
        public async Task<UserModel> Login(string Email, string Password)
        {
            try
            {
                var result = await userDbContext.userModel.FirstOrDefaultAsync(x => x.Email == Email && x.Password == Password);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<UserModel> AddUser(UserModel userModel)
        {
            try
            {
                var result = await userDbContext.userModel.AddAsync(userModel);
                await userDbContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex) { throw ex; }
        }
        public async Task<IEnumerable<UserModel>> GetUser()
        {
            try
            {
                var result = await userDbContext.userModel.ToListAsync();
                return result;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
