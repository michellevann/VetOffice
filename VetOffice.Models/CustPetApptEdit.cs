using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetOffice.Data;

namespace VetOffice.Models
{
    public class CustPetApptEdit
    {
        public int CustPetApptId { get; set; }
        public CustomerEdit Cust { get; set; }
        public PetEdit Pet { get; set; }
        public AppointmentEdit Appt { get; set; }
    }
}
