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
        
        public IEnumerable<CustomerListItem> CustomerListItems { get; set; }
        public IEnumerable<PetListItem> PetListItems { get; set; }
        public IEnumerable<AppointmentListItem> AppointmentListItems { get; set; }
    }
}


