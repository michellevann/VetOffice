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
    [Authorize]
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
            if (!ModelState.IsValid) return View(model);
            var service = CreateReasonService();
            if (service.CreateReason(model))
            {
                ViewBag.SaveResult = "Your reason was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Reason could not be created.");
            return View(model);


        }

        public ActionResult Details(int id)
        {
            var svc = CreateReasonService();
            var model = svc.GetReasonById(id);
            return View(model);
        }

        private ReasonService CreateReasonService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReasonService(userId);
            return service;
        }
    }
}