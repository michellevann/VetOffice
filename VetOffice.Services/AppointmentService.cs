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
            var entity = new Appointment()
            {
                OwnerId = _userId,
                NextAppt = model.NextAppt
            };
            using (var ctx = new ApplicationDbContext())
            {
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
                    .Where(e => e.OwnerId == _userId)
                    .Select(e => new AppointmentListItem
                    {
                        AppointmentId = e.AppointmentId,
                        NextAppt = e.NextAppt,
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
                    .Single(e => e.AppointmentId == appointmentId && e.OwnerId == _userId);
                return new AppointmentDetail
                {
                    AppointmentId = entity.AppointmentId,
                    NextAppt = entity.NextAppt,
                };
            }
        }

        public bool UpdateAppointment(AppointmentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Appointments
                    .Single(e => e.AppointmentId == model.AppointmentId && e.OwnerId == _userId);
                entity.NextAppt = model.NextAppt;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAppointment(int appointmentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Appointments
                    .Single(e => e.AppointmentId == appointmentId && e.OwnerId == _userId);
                ctx.Appointments.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
