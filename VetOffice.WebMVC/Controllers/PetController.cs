using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
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
    public class PetController : Controller
    {
        // GET: Pet
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PetService(userId);
            var model = service.GetPets();
            return View(model);
        }

        private ApplicationDbContext db = new ApplicationDbContext();

        //GET
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "FullName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PetCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreatePetService();
            if (service.CreatePet(model))
            {
                ViewBag.SaveResult = "Your pet was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Pet could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreatePetService();
            var model = svc.GetCustomerPetsById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var svc = CreatePetService();
            var detail = svc.GetPetById(id);
            var model = new PetEdit
            {
                PetId = detail.PetId,
                PetName = detail.PetName,
                TypeOfPet = detail.TypeOfPet,
                Breed = detail.Breed,
                AgeOfPet = detail.AgeOfPet
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PetEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.PetId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreatePetService();
            if (service.UpdatePet(model))
            {
                TempData["SaveResult"] = "Your pet was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your pet could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePetService();
            var detail = svc.GetPetById(id);
            return View(detail);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreatePetService();
            service.DeletePet(id);
            TempData["SaveResult"] = "Your pet was deleted.";
            return RedirectToAction("Index");
        }

        public ActionResult CreateMultiple()
        {
            return View();
        }

        private PetService CreatePetService()
        {
            return new PetService(Guid.Parse(User.Identity.GetUserId()));
        }
    }
}