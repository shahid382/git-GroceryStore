using E_GroceryStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_GroceryStore.Core.Interface
{
    public interface IUser
    {
        Task<UserModel> Login(string Email,string Password);
        Task<IEnumerable<UserModel>> GetUser();
        Task<UserModel> AddUser(UserModel userModel);
    }
}
