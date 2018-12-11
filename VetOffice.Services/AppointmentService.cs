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
                var customer = ctx

                    .Customers
                    .Single(x => x.CustomerId == model.CustomerId);

                var entity = new Appointment
                {
                    Customer = customer,
                    CustomerId = model.CustomerId,
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
                        Customer = e.Customer,
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
                    Customer = entity.Customer,
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
