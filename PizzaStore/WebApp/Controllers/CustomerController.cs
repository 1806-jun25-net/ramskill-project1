using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using PizzaStore.Library.Models;
using PizzaStore.Data;

namespace WebApp.Controllers
{
    public class CustomerController : Controller
    {

        public CustomerWebRepo Repo { get; }

        public CustomerController(CustomerWebRepo repo)
        {
            Repo = repo;
        }

        // GET: Customer/Login
        public ActionResult Login()
        {
            return View();
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            var customer = Repo.GetCustomerById(id);
            var webCust = new CustomerWeb
            {
                id = customer.id,
                firstName = customer.firstName,
                lastName = customer.lastName,
                userName = customer.userName,
                password = customer.password,
                favoriteLocationId = customer.favoriteLocationId,
                admin = customer.admin
            };
            return View(webCust);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            CustomerWeb customer = new CustomerWeb();
            return View(customer);
        }

        // POST: Customer/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(CustomerWeb customer)
        {
            try
            {
                CustomerWeb customerInfo = Repo.Login(customer);

                TempData["CustomerID"] = customerInfo.id;
                TempData["CustomerFirstName"] = customerInfo.firstName;
                TempData["CustomerLastName"] = customerInfo.lastName;
                TempData["CustomerFavoriteLocation"] = customerInfo.favoriteLocationId;
                TempData["CustomerAdmin"] = customerInfo.admin;

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }

        }

        // GET: Customer/Logout
        public ActionResult Logout()
        {
            try
            {
                TempData["CustomerID"] = " ";
                TempData["CustomerFirstName"] = " ";
                TempData["CustomerLastName"] = "";
                TempData["CustomerFavoriteLocation"] = " ";
                TempData["CustomerAdmin"] = " ";

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }

        }
        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerWeb customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Repo.AddCustomer(new CustomerWeb
                    {
                        firstName = customer.firstName,
                        lastName = customer.lastName,
                        userName = customer.userName,
                        password = customer.password,
                        favoriteLocationId = (int)customer.favoriteLocationId
                    });

                    Repo.Save();
                }

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Login));
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Login));
            }
            catch
            {
                return View();
            }
        }
    }
}