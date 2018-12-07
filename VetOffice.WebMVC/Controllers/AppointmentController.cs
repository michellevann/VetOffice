﻿using Microsoft.AspNet.Identity;
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

        //GET
        public ActionResult Create()
        {
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
            var model = svc.GetAppointmentById(id);
            return View(model);
        }

        private AppointmentService CreateAppointmentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AppointmentService(userId);
            return service;
        }
    }
}