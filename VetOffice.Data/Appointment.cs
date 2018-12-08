using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetOffice.Data
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public DateTime NextAppt { get; set; }
    }
}
