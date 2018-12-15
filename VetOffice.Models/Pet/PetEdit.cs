using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string Breed { get; set; }
        public PetAge AgeOfPet { get; set; }
    }
}
