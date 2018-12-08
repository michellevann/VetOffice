using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetOffice.Data;

namespace VetOffice.Models
{
    public class CustPetApptDetail
    {
        public int CustPetApptId { get; set; }
        public CustomerDetail Cust { get; set; }
        public PetDetail Pet { get; set; }
        public AppointmentDetail Appt { get; set; }
    }
}
