using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MasterDetailDemo.Models;
using MasterDetailDemo.ViewModels;

namespace MasterDetailDemo.Controllers
{
    public class OrdersController : Controller
    {
        OnlineShopEntities db = new OnlineShopEntities();
        // GET: Order
        public ActionResult Index()
        {
            var orderAndCustomerList = db.Customers.ToList();
            return View(orderAndCustomerList);
        }

        public ActionResult Create()
        {
            var order = new OrderViewModel();
            
            return View(order);
        }

        [HttpPost]
        public ActionResult Create(Customer customer, Order[] order)
        {
            return View();
        }

        public ActionResult SaveOrder(string name, string address, Order[] order)
        {
            string result = "Error! Order is Not Complete";
            if (name != null || address != null || order != null)
            {
                var customerId = Guid.NewGuid();
                Customer model = new Customer();
                model.CustomerId = customerId;
                model.Name = name;
                model.Address = address;
                model.OrderDate = DateTime.Now;
                db.Customers.Add(model);
                foreach (var item in order)
                {
                    var orderId = Guid.NewGuid();
                    Order o = new Order
                    {
                        OrderId = orderId,
                        ProductName = item.ProductName,
                        Quantity = item.Quantity,
                        Price = item.Price,
                        Amount = item.Amount,
                        CustomerId = customerId
                    };
                    db.Orders.Add(o);
                }

                db.SaveChanges();
                result = "Success ! Order is completed";

            }
            return Json(result);
        }
    }

  
}