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
        public int CustomerId { get; set; }
        public int PetId { get; set; }
        [Required]
        public DateTime NextAppt { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Pet Pet { get; set; }
    }
}
