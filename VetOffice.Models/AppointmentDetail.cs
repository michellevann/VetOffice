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
        public int ReasonId { get; set; }
        [Display(Name = "Next Appointment")]
        public DateTime NextAppt { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Reason Reason { get; set; }
    }
}
