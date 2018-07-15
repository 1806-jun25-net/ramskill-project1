﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaStore.Data;
using PizzaStore.Library.Repositories;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class OrderController : Controller
    {

        public OrderRepository Repo { get; }

        public OrderController(OrderRepository repo)
        {
            Repo = repo;
        }
        


        // GET: Order
        public ActionResult Index()
        {
            OrderWeb order = new OrderWeb();
            return View(order);
        }

        // GET: Order/OrderConfirmation/5
        public ActionResult OrderConfirmation(DateTime dateTime)
        {
            OrderWeb order = Repo.GetOrderByDateTime(dateTime);
            var loc = Repo.GetLocationById(order.LocationId);
            TempData["LocationName"] = loc.Name;
            var cust = Repo.GetCustomerById(order.CustomerId);
            TempData["CustomerFirstName"] = cust.firstName;
            TempData["CustomerLastName"] = cust.lastName;
            //pizza1
            if(order.Pizza1Id != 0)
            {
                var pizza = Repo.GetPizzaById(order.Pizza1Id);
                TempData["Pizza1"] = pizza.Name;
            }
            else
            {
                TempData["Pizza1"] = "noPizza";

            }
            //pizza2
            if (order.Pizza2Id != 0)
            {
                var pizza = Repo.GetPizzaById(order.Pizza2Id);
                TempData["Pizza2"] = pizza.Name;
            }
            else
            {
                TempData["Pizza2"] = "noPizza";
            }
            //pizza3
            if (order.Pizza3Id != 0)
            {
                var pizza = Repo.GetPizzaById(order.Pizza3Id);
                TempData["Pizza3"] = pizza.Name;
            }
            else
            {
                TempData["Pizza3"] = "noPizza";
            }
            //pizza4
            if (order.Pizza4Id != 0)
            {
                var pizza = Repo.GetPizzaById(order.Pizza4Id);
                TempData["Pizza4"] = pizza.Name;
            }
            else
            {
                TempData["Pizza4"] = "noPizza";
            }
            //pizza5
            if (order.Pizza5Id != 0)
            {
                var pizza = Repo.GetPizzaById(order.Pizza5Id);
                TempData["Pizza5"] = pizza.Name;
            }
            else
            {
                TempData["Pizza5"] = "noPizza";
            }
            //pizza6
            if (order.Pizza6Id != 0)
            {
                var pizza = Repo.GetPizzaById(order.Pizza6Id);
                TempData["Pizza6"] = pizza.Name;
            }
            else
            {
                TempData["Pizza6"] = "noPizza";
            }
            //pizza7
            if (order.Pizza7Id != 0)
            {
                var pizza = Repo.GetPizzaById(order.Pizza7Id);
                TempData["Pizza7"] = pizza.Name;
            }
            else
            {
                TempData["Pizza7"] = "noPizza";
            }
            //pizza8
            if (order.Pizza8Id != 0)
            {
                var pizza = Repo.GetPizzaById(order.Pizza8Id);
                TempData["Pizza8"] = pizza.Name;
            }
            else
            {
                TempData["Pizza8"] = "noPizza";
            }
            //pizza9
            if (order.Pizza9Id != 0)
            {
                var pizza = Repo.GetPizzaById(order.Pizza9Id);
                TempData["Pizza9"] = pizza.Name;
            }
            else
            {
                TempData["Pizza9"] = "noPizza";
            }
            //pizza10
            if (order.Pizza10Id != 0)
            {
                var pizza = Repo.GetPizzaById(order.Pizza10Id);
                TempData["Pizza10"] = pizza.Name;
            }
            else
            {
                TempData["Pizza10"] = "noPizza";
            }
            //pizza11
            if (order.Pizza11Id != 0)
            {
                var pizza = Repo.GetPizzaById(order.Pizza11Id);
                TempData["Pizza11"] = pizza.Name;
            }
            else
            {
                TempData["Pizza11"] = "noPizza";
            }
            //pizza12
            if (order.Pizza12Id != 0)
            {
                var pizza = Repo.GetPizzaById(order.Pizza12Id);
                TempData["Pizza12"] = pizza.Name;
            }
            else
            {
                TempData["Pizza12"] = "noPizza";
            }

            return View(order);
        }

        // GET: Order/StartOrder
        public ActionResult StartOrder()
        {
            OrderWeb order = new OrderWeb();
            return View(order);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            OrderWeb order = new OrderWeb();
            return View(order);
        }

        // POST: Order/StartOrder
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StartOrder(OrderWeb order)
        {
            try
            {
                TempData["PizzaCount"] = order.PizzaCount;
                TempData["LocationID"] = order.LocationId;
                
                return RedirectToAction("Create", "Order");
            }

            catch
            {
                return View();
            }
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderWeb order)
        {
            try
            {
                order.LocationId = (int)TempData["LocationID"];
                order.PizzaCount = (int)TempData["PizzaCount"];
                order.CustomerId = (int)TempData["CustomerId"]; //make Order only show up when customer logs in
                order.Dt = DateTime.Now;
                order.Total = 0;

                //populate total
                for(int i = 0; i < order.PizzaCount; i++)
                {
                    var pizza = Repo.GetPizza(order.PizzaId[i], order.PizzaSize[i]);
                    order.Total += pizza.Cost;
                }
                
                //if order is over $500, redirect to order page
                if (order.Total > 500)
                {
                    return RedirectToAction("Create", "Order");
                }

                //Pizza1ID
                try
                {
                    if (order.PizzaId[0] > 0)
                    {
                        order.Pizza1Id = order.PizzaId[0];
                    }
                }
                catch { }
                //Pizza2ID
                try
                {
                    if (order.PizzaId[1] > 0)
                    {
                        order.Pizza2Id = order.PizzaId[1];
                    }
                }
                catch { }
                //Pizza3ID
                try
                {
                    if (order.PizzaId[2] > 0)
                    {
                        order.Pizza3Id = order.PizzaId[2];
                    }
                }
                catch { }
                //Pizza4ID
                try
                {
                    if (order.PizzaId[3] > 0)
                    {
                        order.Pizza4Id = order.PizzaId[3];
                    }
                }
                catch { }
                //Pizza5ID
                try
                {
                    if (order.PizzaId[4] > 0)
                    {
                        order.Pizza5Id = order.PizzaId[4];
                    }
                }
                catch { }
                //Pizza6ID
                try
                {
                    if (order.PizzaId[5] > 0)
                    {
                        order.Pizza6Id = order.PizzaId[5];
                    }
                }
                catch { }
                //Pizza7ID
                try
                {
                    if (order.PizzaId[6] > 0)
                    {
                        order.Pizza7Id = order.PizzaId[6];
                    }
                }
                catch { }
                //Pizza8ID
                try
                {
                    if (order.PizzaId[7] > 0)
                    {
                        order.Pizza8Id = order.PizzaId[7];
                    }
                }
                catch { }
                //Pizza9ID
                try
                {
                    if (order.PizzaId[8] > 0)
                    {
                        order.Pizza9Id = order.PizzaId[8];
                    }
                }
                catch { }
                //Pizza10ID
                try
                {
                    if (order.PizzaId[9] > 0)
                    {
                        order.Pizza10Id = order.PizzaId[9];
                    }
                }
                catch { }
                //Pizza11ID
                try
                {
                    if (order.PizzaId[10] > 0)
                    {
                        order.Pizza11Id = order.PizzaId[10];
                    }
                }
                catch { }
                //Pizza12ID
                try
                {
                    if (order.PizzaId[11] > 0)
                    {
                        order.Pizza12Id = order.PizzaId[11];
                    }
                }
                catch { }

                Repo.AddOrder(order);
                Repo.Save();




                return RedirectToAction("OrderConfirmation", "Order", new {dateTime = order.Dt});
            }
            
            catch
            {
                return View();
            }
        }

        // GET: Order/SortSelection
        public ActionResult SortSelection()
        {
            OrderWeb order = new OrderWeb();
            return View(order);
        }

        // POST: Order/SortSelection
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SortSelection(OrderWeb order)
        {
            try
            {
                return RedirectToAction("OrderHistory", "Order", new { sortID = order.sortSelect });
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/OrderHistory
        public ActionResult OrderHistory(string sortID)
        {
            var orderList = Repo.GetOrderHistoryByCustomerId((int)TempData.Peek("CustomerId"));
            IEnumerable<OrderWeb> orderHistory = new List<OrderWeb>();

            switch (sortID)
            {
                case "PriceLow":
                    orderHistory = orderList.OrderBy(x => x.Total);
                    break;

                case "PriceHigh":
                    orderHistory = orderList.OrderByDescending(x => x.Total);
                    break;

                case "Oldest":
                    orderHistory = orderList.OrderBy(x => x.Dt);
                    break;

                case "Newest":
                    orderHistory = orderList.OrderByDescending(x => x.Dt);
                    break;

                default:
                    orderHistory = orderList;
                    break;
            }

            //save customer name
            CustomerWeb customer = Repo.GetCustomerById((int)TempData.Peek("CustomerId"));
            TempData["CustomerFirstName"] = customer.firstName;
            TempData["CustomerLastName"] = customer.lastName;
            //save location and pizza names
            TempData["LocationId1"] = "Reston";
            TempData["LocationId1"] = "Ashburn";
            TempData["LocationId1"] = "Sterling";
            TempData["PizzaId1"] = "Cheese";
            TempData["PizzaId2"] = "Pepperoni";
            TempData["PizzaId3"] = "Meat Lovers";
            TempData["PizzaId4"] = "Veggie";
            TempData["PizzaId5"] = "Hawaiian";
            TempData["PizzaId6"] = "Golden Sun";

            return View(orderHistory);
        }

        
        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}