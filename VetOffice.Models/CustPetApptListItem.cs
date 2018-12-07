using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetOffice.Data;

namespace VetOffice.Models
{
    public class CustPetApptListItem
    {
        public int CustPetApptId { get; set; }
        public Customer Cust { get; set; }
        public Pet Pet { get; set; }
        public Appointment Appt { get; set; }
        public IEnumerable<CustomerListItem> CustomerListItems { get; set; }
        public IEnumerable<PetListItem> PetListItems { get; set; }
        public IEnumerable<AppointmentListItem> AppointmentListItems { get; set; }
    }
}

