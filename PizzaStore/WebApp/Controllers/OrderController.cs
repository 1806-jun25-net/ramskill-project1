using System;
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