using E_GroceryStore.Core.Interface;
using E_GroceryStore.Models;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_GroceryStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IUser _context;
        public UserController(IUser _context)
        {
            this._context = _context;
        }
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login(string Email, string Password)
        {
            try
            {
                var userList = await _context.Login(Email,Password);
                if (userList == null)
                {
                    log.Error("Invalid Credentials");
                    return BadRequest("Invalid Credentials");
                }
                log.Info("Login Success");
                return Ok("Login Successfull");
            }
            catch (Exception ex)
            {
                log.Error("Error Occur");
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult> GetUser()
        {
            try
            {
                log.Info("Data Successfully Displayed");
                return Ok(await _context.GetUser());
            }
            catch (Exception)
            {
                log.Error("Error Retrieving Data from the Database");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retrieving Data from the Database");
            }
        }
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<UserModel>> AddUser(UserModel userModel)
        {
            try
            {
                if (userModel == null)
                {
                    log.Error("No Data");
                    return BadRequest("No Data");
                }
                var addUser = await _context.AddUser(userModel);
                log.Info("Created Successfully");
                return CreatedAtAction(nameof(GetUser), new { id = addUser.UserId }, addUser);
            }
            catch (Exception)
            {
                log.Error("Error Adding Data to the Database");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Adding Data to the Database");
            }
        }
    }
}