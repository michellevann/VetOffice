using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetOffice.Data;

namespace VetOffice.Models
{
    public class AppointmentCreate
    {
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Next Appointment")]
        public DateTime NextAppt { get; set; }

        public int CustomerId { get; set; }
        public int ReasonId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Reason Reason { get; set; }
    }
}
