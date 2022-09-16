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
    public class GroceryItemsController : ControllerBase
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IGroceryItems _context;
        public GroceryItemsController(IGroceryItems _context)
        {
            this._context = _context;
        }
        [HttpGet]
        public async Task<IActionResult> GetGroceryItems()
        {
            try
            {
                log.Info("Data Successfull Displayed");
                var result = _context.GetGroceryItems();
                return StatusCode(200, result);
            }
            catch (Exception)
            {
                log.Error("Error Occur");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retrieving Data from the Database");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddGrocery(GroceryItemsModel groceryItemsModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _context.AddGrocery(groceryItemsModel);
                    log.Info("Created Successfully");
                    return StatusCode(200, "Created Successfully");
                }
                else
                {
                    log.Error("Something Went Wrong");
                    return BadRequest("Something Went Wrong");
                }
            }
            catch (Exception)
            {
                log.Error("Error Occur");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Adding Data to the Database");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateGrocery(GroceryItemsModel groceryItemsModel)
        {
            try
            {
                var result = _context.UpdateGrocery(groceryItemsModel);
                log.Info("Updated Successfully");
                return StatusCode(200, "Updated Successfully");
            }
            catch (Exception)
            {
                log.Error("Error Occur");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating Data to the Database");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteGrocery(int groceryId)
        {
            try
            {
                var result = _context.DeleteGrocery(groceryId);
                log.Info("Deleted Successfully");
                return StatusCode(200, "Deleted Successfully");
            }
            catch (Exception)
            {
                log.Error("Error Occur");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Deleting Data to the Database");
            }
        }
    }
}