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
    public class AppointmentController : Controller
    {
        // GET: Appointment
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AppointmentService(userId);
            var model = service.GetAppointments();
            return View(model);
        }

        private ApplicationDbContext db = new ApplicationDbContext();

        //GET
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "FullName");
            ViewBag.PetId = new SelectList(db.Pets, "PetId", "PetName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AppointmentCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateAppointmentService();
            if (service.CreateAppointment(model))
            {
                ViewBag.SaveResult = "Your appointment was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Appointment could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateAppointmentService();
            var detail = svc.GetAppointmentById(id);
            return View(detail);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateAppointmentService();
            var detail = service.GetAppointmentById(id);
            var model = new AppointmentEdit
            {
                AppointmentId = detail.AppointmentId,
                NextAppt = detail.NextAppt,
                ApptTime = detail.ApptTime,
                ReasonForVisit = detail.ReasonForVisit
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AppointmentEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.AppointmentId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateAppointmentService();
            if (service.UpdateAppointment(model))
            {
                TempData["SaveResult"] = "Your appointment was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your appointment could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateAppointmentService();
            var model = svc.GetAppointmentById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateAppointmentService();
            service.DeleteAppointment(id);
            TempData["SaveResult"] = "Your appointment was deleted.";
            return RedirectToAction("Index");
        }

        private AppointmentService CreateAppointmentService()
        {
            return new AppointmentService(Guid.Parse(User.Identity.GetUserId()));
        }
    }
}