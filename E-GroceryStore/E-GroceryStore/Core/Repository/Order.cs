using E_GroceryStore.Core.Interface;
using E_GroceryStore.DataAccess;
using E_GroceryStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_GroceryStore.Core.Repository
{
    public class Order:IOrder
    {
        private readonly CrudDbContext _context;
        public Order(CrudDbContext _context)
        {
            this._context = _context;
        }
        public List<OrderModel> GetOrder()
        {
            try
            {
                var result = _context.orderModel.ToList();
                return result;
            }
            catch (Exception ex) { throw ex; }
        }
        public OrderModel AddOrder(OrderModel orderModel)
        {
            try
            {
                _context.orderModel.AddAsync(orderModel);
                _context.SaveChangesAsync();
                return orderModel;
            }
            catch (Exception ex) { throw ex; }
        }
        public OrderModel UpdateOrder(OrderModel orderModel)
        {
            var result = _context.orderModel.FirstOrDefault(x => x.OrderId == orderModel.OrderId);
            if (result != null)
            {
                result.GroceryName = orderModel.GroceryName;
                result.CustomerName = orderModel.CustomerName;
                result.MobileNumber = orderModel.MobileNumber;
                result.Address = orderModel.Address;
                _context.SaveChanges();
                return result;
            }
            return null;
        }
        public OrderModel DeleteOrder(int orderId)
        {
            try
            {
                var result = _context.orderModel.FirstOrDefault(x => x.OrderId == orderId);
                if (result != null)
                {
                    _context.orderModel.Remove(result);
                    _context.SaveChanges();
                }
                return result;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
