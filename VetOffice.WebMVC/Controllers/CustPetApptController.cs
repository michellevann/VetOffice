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
    public class CustPetApptController : Controller
    {
        // GET: CustPetAppt
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());

            var service = new CustomerService(userId);
            var serviceOne = new PetService(userId);
            var serviceTwo = new AppointmentService(userId);

            var model = service.GetCustomers();
            var modelOne = serviceOne.GetPets();
            var modelTwo = serviceTwo.GetAppointments();

            var appts = new
            {
                Customers = model,
                Pets = modelOne,
                Appointments = modelTwo
            };

            return View(appts);
        }


        //GET
        public ActionResult CreateCustPetAppt()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCustPetAppt(CustPetApptCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);
            CustomerService service = new CustomerService(Guid.Parse(User.Identity.GetUserId()));
            PetService petService = new PetService(Guid.Parse(User.Identity.GetUserId()));
            AppointmentService apptService = new AppointmentService(Guid.Parse(User.Identity.GetUserId()));
            var info = new
            {
               CustomerService = service,
               PetService = petService,
               AppointmentService = apptService
            };
            return View(info);
            //if (info.CreateCustPetAppt(model))
            //{
               // ViewBag.SaveResult = "Your customer, pet, and appointment was created.";
               // return RedirectToAction("Index");
            //};
            //ModelState.AddModelError("", "Customer, pet, and appointment could not be created.");
            //return View(model);
        }
    }
}