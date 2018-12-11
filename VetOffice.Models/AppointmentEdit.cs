using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetOffice.Data;

namespace VetOffice.Models
{
    public class AppointmentEdit
    {
        [Key]
        public int AppointmentId { get; set; }

        public DateTime NextAppt { get; set; }
        public VisitReason ReasonForVisit { get; set; }
        public string ApptTime { get; set; }
    }
}
