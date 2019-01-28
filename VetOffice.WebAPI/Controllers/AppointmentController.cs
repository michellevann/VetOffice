using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VetOffice.Models;
using VetOffice.Services;

namespace VetOffice.WebAPI.Controllers
{
    [Authorize]
    public class AppointmentController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            AppointmentService appointmentService = CreateAppointmentService();
            var appointments = appointmentService.GetAppointments();
            return Ok(appointments);
        }

        public IHttpActionResult Get(int id)
        {
            AppointmentService appointmentService = CreateAppointmentService();
            var appointment = appointmentService.GetAppointmentById(id);
            return Ok(appointment);
        }

        public IHttpActionResult Post(AppointmentCreate appointment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateAppointmentService();
            if (!service.CreateAppointment(appointment))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Put(AppointmentEdit appointment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateAppointmentService();
            if (!service.UpdateAppointment(appointment))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateAppointmentService();
            if (!service.DeleteAppointment(id))
                return InternalServerError();
            return Ok();
        }

        private AppointmentService CreateAppointmentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var appointmentService = new AppointmentService(userId);
            return appointmentService;
        }
    }
}
