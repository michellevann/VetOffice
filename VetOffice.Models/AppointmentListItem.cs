using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetOffice.Data;

namespace VetOffice.Models
{
    public class AppointmentListItem
    {
        public int AppointmentId { get; set; }
        public int CustomerId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Next Appointment")]
        public DateTime NextAppt { get; set; }
        [Display(Name = "Reason for Visit")]
        public VisitReason ReasonForVisit { get; set; }
        [Display(Name = "Appointment Time")]
        public string ApptTime { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
