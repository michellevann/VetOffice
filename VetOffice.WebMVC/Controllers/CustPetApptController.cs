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

            CustPetApptListItem appts = new CustPetApptListItem
            {
                CustomerListItems = model,
                PetListItems = modelOne,
                AppointmentListItems = modelTwo
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
        public ActionResult Create(CustPetApptCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            CustomerService service = new CustomerService(Guid.Parse(User.Identity.GetUserId()));
            PetService petService = new PetService(Guid.Parse(User.Identity.GetUserId()));
            AppointmentService apptService = new AppointmentService(Guid.Parse(User.Identity.GetUserId()));
           
            if (service.CreateCustomer(model.Cust) && petService.CreatePet(model.Pet) && apptService.CreateAppointment(model.Appt))
            {
                ViewBag.SaveResult = "Your appointment was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Appointment could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            CustomerService service = new CustomerService(Guid.Parse(User.Identity.GetUserId()));
            PetService petService = new PetService(Guid.Parse(User.Identity.GetUserId()));
            AppointmentService apptService = new AppointmentService(Guid.Parse(User.Identity.GetUserId()));

            var model = service.GetCustomerById(id);
            var modelOne = petService.GetPetById(id);
            var modelTwo = apptService.GetAppointmentById(id);

            var appts = new
            {
                CustomerId = model,
                PetId = modelOne,
                AppointmentId = modelTwo
            };

            return View(appts);
        }

        [ActionName("Edit")]
        public ActionResult Edit(int id)
        {
            CustomerService service = new CustomerService(Guid.Parse(User.Identity.GetUserId()));
            PetService petService = new PetService(Guid.Parse(User.Identity.GetUserId()));
            AppointmentService apptService = new AppointmentService(Guid.Parse(User.Identity.GetUserId()));

            CustomerDetail detail = service.GetCustomerById(id);
            PetDetail detailOne = petService.GetPetById(id);
            AppointmentDetail detailTwo = apptService.GetAppointmentById(id);

            var model = new 
            {
                
            
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustPetApptEdit model)
        {
            if (!ModelState.IsValid) return View(model);
         
            CustomerService service = new CustomerService(Guid.Parse(User.Identity.GetUserId()));
            PetService petService = new PetService(Guid.Parse(User.Identity.GetUserId()));
            AppointmentService apptService = new AppointmentService(Guid.Parse(User.Identity.GetUserId()));
            
            if (service.UpdateCustomer(model.Cust) && petService.UpdatePet(model.Pet) && apptService.UpdateAppointment(model.Appt))
            {
                TempData["SaveResult"] = "Your appointment was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Appointment could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            CustomerService service = new CustomerService(Guid.Parse(User.Identity.GetUserId()));
            PetService petService = new PetService(Guid.Parse(User.Identity.GetUserId()));
            AppointmentService apptService = new AppointmentService(Guid.Parse(User.Identity.GetUserId()));

            var model = service.GetCustomerById(id);
            var modelOne = petService.GetPetById(id);
            var modelTwo = apptService.GetAppointmentById(id);

            var appts = new
            {
                CustomerId = model,
                PetId = modelOne,
                AppointmentId = modelTwo
            };

            return View(appts);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            CustomerService service = new CustomerService(Guid.Parse(User.Identity.GetUserId()));
            PetService petService = new PetService(Guid.Parse(User.Identity.GetUserId()));
            AppointmentService apptService = new AppointmentService(Guid.Parse(User.Identity.GetUserId()));
            service.DeleteCustomer(id);
            petService.DeletePet(id);
            apptService.DeleteAppointment(id);
            TempData["SaveResult"] = "Your appointment was deleted.";
            return RedirectToAction("Index");
        }
    }
}