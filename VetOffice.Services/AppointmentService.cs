using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetOffice.Data;
using VetOffice.Models;

namespace VetOffice.Services
{
    public class AppointmentService
    {
        private readonly Guid _userId;
        public AppointmentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateAppointment(AppointmentCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var pet = ctx
                    .Pets
                    .Single(x => x.PetId == model.PetId);
              
                var entity = new Appointment
                {
                    AppointmentId = model.AppointmentId,
                    CustomerId = model.CustomerId,
                    PetId = model.PetId,
                    Pet = pet,
                    NextAppt = model.NextAppt,
                    ApptTime = model.ApptTime,
                    ReasonForVisit = model.ReasonForVisit
                };

                ctx.Appointments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
               
        public IEnumerable<AppointmentListItem> GetAppointments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Appointments
                    .Select(e => new AppointmentListItem
                    {
                        AppointmentId = e.AppointmentId,
                        CustomerId = e.CustomerId,
                        PetId = e.PetId,
                        Pet = e.Pet,
                        FullName = e.Pet.Customer.FullName,
                        NextAppt = e.NextAppt,
                        ApptTime = e.ApptTime,
                        ReasonForVisit = e.ReasonForVisit
                    });
                return query.ToArray();
            }
        }

        public AppointmentDetail GetAppointmentById(int appointmentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Appointments
                    .Single(e => e.AppointmentId == appointmentId);
                return new AppointmentDetail
                {
                    AppointmentId = entity.AppointmentId,
                    CustomerId = entity.CustomerId,
                    PetId = entity.PetId,
                    Pet = entity.Pet,
                    FullName = entity.Pet.Customer.FullName,
                    NextAppt = entity.NextAppt,
                    ApptTime = entity.ApptTime,
                    ReasonForVisit = entity.ReasonForVisit
                };
            }
        }

        public bool UpdateAppointment(AppointmentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Appointments
                    .Single(e => e.AppointmentId == model.AppointmentId);

                entity.NextAppt = model.NextAppt;
                entity.ApptTime = model.ApptTime;
                entity.ReasonForVisit = model.ReasonForVisit;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAppointment(int appointmentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Appointments
                    .Single(e => e.AppointmentId == appointmentId);
                ctx.Appointments.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
