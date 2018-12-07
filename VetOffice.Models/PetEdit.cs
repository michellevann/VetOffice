using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetOffice.Data;

namespace VetOffice.Models
{
    public class PetEdit
    {
        public int PetId { get; set; }
        public string PetName { get; set; }
        public PetType TypeOfPet { get; set; }
        public PetAge AgeOfPet { get; set; }
        public VisitReason ReasonForVisit { get; set; }
    }
}
