using E_GroceryStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_GroceryStore.Core.Interface
{
    public interface IOrder
    {
        List<OrderModel> GetOrder();
        OrderModel AddOrder(OrderModel orderModel);
        OrderModel UpdateOrder(OrderModel orderModel);
        OrderModel DeleteOrder(int orderId);
    }
}
