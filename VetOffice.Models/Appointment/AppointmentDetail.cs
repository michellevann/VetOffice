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

    public class AppointmentDetail
    {
        [Key]
        public int AppointmentId { get; set; }
        public int CustomerId { get; set; }
        public int PetId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Next Appointment")]
        public DateTime NextAppt { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Appointment Time")]
        public DateTime ApptTime { get; set; }

        [Display(Name = "Reason for Visit")]
        public VisitReason ReasonForVisit { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        public virtual Pet Pet { get; set; }
    }
}
