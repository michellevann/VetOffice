using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VetOffice.Data;
using VetOffice.Models;
using VetOffice.Services;

namespace VetOffice.WebMVC.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            using(var ctx = new ApplicationDbContext())
            {
                    //var customers = from c in ctx.Customers
                    //            select c;
                    var userId = Guid.Parse(User.Identity.GetUserId());
                    var service = new CustomerService(userId);
                    var model = service.GetCustomers();

                    //customers = customers.OrderBy(c => c.LastName);
                    return View(model);
            };
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var service = new CustomerService(Guid.Parse(User.Identity.GetUserId()));
            if (service.CreateCustomer(model))
            {
                ViewBag.SaveResult = "Your customer was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Customer could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateCustomerService();
            var model = svc.GetCustomerById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateCustomerService();
            var detail = service.GetCustomerById(id);
            var model = new CustomerEdit
            {
                CustomerId = detail.CustomerId,
                FirstName = detail.FirstName,
                LastName = detail.LastName,
                StreetAddress = detail.StreetAddress,
                City = detail.City,
                State = detail.State,
                ZipCode = detail.ZipCode
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.CustomerId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateCustomerService();
            if (service.UpdateCustomer(model))
            {
                TempData["SaveResult"] = "Your customer was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your customer could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCustomerService();
            var model = svc.GetCustomerById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCustomerService();
            service.DeleteCustomer(id);
            TempData["SaveResult"] = "Your appointment was deleted.";
            return RedirectToAction("Index");
        }

        private CustomerService CreateCustomerService()
        {
            return new CustomerService(Guid.Parse(User.Identity.GetUserId()));
        }
    }
}