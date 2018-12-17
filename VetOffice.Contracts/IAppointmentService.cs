using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetOffice.Models;

namespace VetOffice.Contracts
{
    public interface IAppointmentService
    {
        bool CreateAppointment(AppointmentCreate model);
        IEnumerable<AppointmentListItem> GetAppointments();
        AppointmentDetail GetAppointmentById(int appointmentId);
        bool UpdateAppointment(AppointmentEdit model);
        bool DeleteAppointment(int appointmentId);
    }
}
