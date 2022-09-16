using AutoFixture;
using E_GroceryStore.Controllers;
using E_GroceryStore.Core.Interface;
using E_GroceryStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OrderControllerTest
{
    [TestClass]
    public class OrderTest
    {
        private Mock<IOrder> _orderRepoMock;
        private Fixture _fixture;
        private OrderController _controller;
        public OrderTest()
        {
            _fixture = new Fixture();
            _orderRepoMock = new Mock<IOrder>();
        }
        [TestMethod]

        public async Task GetOrderReturnOk()
        {
            var orderList = _fixture.CreateMany<OrderModel>(3).ToList();
            _orderRepoMock.Setup(repo => repo.GetOrder()).Returns(orderList);
            _controller = new OrderController(_orderRepoMock.Object);
            var result = await _controller.GetOrder();
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);
        }
        [TestMethod]

        public async Task GetorderThrowException()
        {
            _orderRepoMock.Setup(repo => repo.GetOrder()).Throws(new Exception());
            _controller = new OrderController(_orderRepoMock.Object);
            var result = await _controller.GetOrder();
            var obj = result as ObjectResult;
            Assert.AreEqual(500, obj.StatusCode);
        }
        [TestMethod]

        public async Task AddOrderReturnOk()
        {
            var order = _fixture.Create<OrderModel>();
            _orderRepoMock.Setup(repo => repo.AddOrder(It.IsAny<OrderModel>())).Returns(order);
            _controller = new OrderController(_orderRepoMock.Object);
            var result = await _controller.AddOrder(order);
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);
        }
        [TestMethod]

        public async Task AddOrderThrowException()
        {
            var order = _fixture.Create<OrderModel>();
            _orderRepoMock.Setup(repo => repo.AddOrder(It.IsAny<OrderModel>())).Throws(new Exception());
            _controller = new OrderController(_orderRepoMock.Object);
            var result = await _controller.AddOrder(order);
            var obj = result as ObjectResult;
            Assert.AreEqual(500, obj.StatusCode);
        }
        [TestMethod]

        public async Task UpdateOrderReturnOk()
        {
            var order = _fixture.Create<OrderModel>();
            _orderRepoMock.Setup(repo => repo.UpdateOrder(It.IsAny<OrderModel>())).Returns(order);
            _controller = new OrderController(_orderRepoMock.Object);
            var result = await _controller.UpdateOrder(order);
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);
        }
        [TestMethod]

        public async Task UpdateOrderThrowException()
        {
            var order = _fixture.Create<OrderModel>();
            _orderRepoMock.Setup(repo => repo.UpdateOrder(It.IsAny<OrderModel>())).Throws(new Exception());
            _controller = new OrderController(_orderRepoMock.Object);
            var result = await _controller.UpdateOrder(order);
            var obj = result as ObjectResult;
            Assert.AreEqual(500, obj.StatusCode);
        }
        [TestMethod]

        public async Task DeleteOrderReturnOk()
        {
            var order = _fixture.Create<OrderModel>();
            _orderRepoMock.Setup(repo => repo.DeleteOrder(It.IsAny<int>())).Returns(order);
            _controller = new OrderController(_orderRepoMock.Object);
            var result = await _controller.DeleteOrder(It.IsAny<int>());
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);
        }
        [TestMethod]

        public async Task DeleteOrderThrowException()
        {
            var order = _fixture.Create<OrderModel>();
            _orderRepoMock.Setup(repo => repo.DeleteOrder(It.IsAny<int>())).Throws(new Exception());
            _controller = new OrderController(_orderRepoMock.Object);
            var result = await _controller.DeleteOrder(It.IsAny<int>());
            var obj = result as ObjectResult;
            Assert.AreEqual(500, obj.StatusCode);
        }
    }
}
