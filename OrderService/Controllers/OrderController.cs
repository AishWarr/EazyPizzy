using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderService.Models;
using ef = OrderService.EFModels;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ef.OrderServiceDB_Context dB_Context;
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger, ef.OrderServiceDB_Context orderServiceDB_)
        {
            _logger = logger;
            dB_Context = orderServiceDB_;
        }

        [HttpGet]
        public void Get()
        {

        }

        [HttpPost]
        public Order SubmitOrder(Order order)
        {
            List<ef.Pizza> pizzaList = new List<ef.Pizza>();
            foreach (var pizza in order.PizzaList)
            {
                string toppingList = "";
                foreach (var topping in pizza.SelectedToppingList)
                {
                    toppingList = toppingList + "," + topping.Id.ToString();
                }
                ef.Pizza pizzaItem = new ef.Pizza()
                {
                    ToppingList = toppingList,
                    Quantity = pizza.Quantity
                };
                pizzaList.Add(pizzaItem);
            }
            using (var db = new ef.OrderServiceDB_Context())
            {
                try
                {
                    var prevOrder = db.Orders.OrderByDescending(o => o.Id).FirstOrDefault();
                    int? orderNo = 1;
                    if (prevOrder != null)
                        orderNo = prevOrder.OrderNo + 1;

                    DateTime today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                    var lastOrderFromSameOutlet = db.Orders.Where(t => t.OutletId == order.OutletId && t.OrderDate >= today)
                                                        .OrderByDescending(o => o.OrderDate).FirstOrDefault();
                    int? newToken = 1;
                    if (lastOrderFromSameOutlet != null)
                        newToken = lastOrderFromSameOutlet.TokenNo + 1;
                    order.TokenNo = newToken;

                    ef.Order newOrder = new ef.Order()
                    {
                        OrderNo = orderNo,
                        OutletId = order.OutletId,
                        TokenNo = newToken,
                        OrderDate = System.DateTime.Now,
                        Pizzas = pizzaList
                    };

                    db.Orders.Add(newOrder);
                    db.SaveChanges();

                    order.Id = newOrder.Id;

                    return order;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
