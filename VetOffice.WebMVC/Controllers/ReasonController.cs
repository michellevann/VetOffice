using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VetOffice.Models;
using VetOffice.Services;

namespace VetOffice.WebMVC.Controllers
{
    public class ReasonController : Controller
    {
        // GET: Reason
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReasonService(userId);
            var model = service.GetReasons();
            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReasonCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var service = new ReasonService(Guid.Parse(User.Identity.GetUserId()));
            if (service.CreateReason(model))
            {
                ViewBag.SaveResult = "The reason for the visit is stored.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "The reason for the visit could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateReasonService();
            var model = svc.GetReasonById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            ReasonService service = CreateReasonService();
            ReasonDetail detail = service.GetReasonById(id);
            ReasonEdit model = new ReasonEdit
            {
                ReasonForVisit = detail.ReasonForVisit
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ReasonEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.ReasonId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateReasonService();
            if (service.UpdateReason(model))
            {
                TempData["SaveResult"] = "The reason for the visit was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "The reason for the visit could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateReasonService();
            var model = svc.GetReasonById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateReasonService();
            service.DeleteReason(id);
            TempData["SaveResult"] = "The reason for the visit was deleted.";
            return RedirectToAction("Index");
        }

        private ReasonService CreateReasonService()
        {
            return new ReasonService(Guid.Parse(User.Identity.GetUserId()));
        }
    }
}