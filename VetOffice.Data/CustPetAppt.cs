using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetOffice.Data
{
    public class CustPetAppt
    {
        [Key]
        public int CustPetApptId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        public Customer Cust { get; set; }
        public Pet Pet { get; set; }
        public Appointment Appt { get; set; }
    }
}
