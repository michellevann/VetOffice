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
        public int PetId { get; set; }
        [Display(Name = "Next Appointment")]
        public DateTime NextAppt { get; set; }

        public virtual Customer  Customer{ get; set; }
        public virtual Pet Pet { get; set; }
    }
}
