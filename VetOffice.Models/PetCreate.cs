using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetOffice.Data;

namespace VetOffice.Models
{
    public class PetCreate
    {
        [Required]
        [Display(Name ="Pet Name")]
        public string PetName { get; set; }
        [Required]
        [Display(Name = "Type of Pet")]
        public PetType TypeOfPet { get; set; }
        [Required]
        [Display(Name = "Age of Pet")]
        public PetAge AgeOfPet { get; set; }
        [Required]
        [Display(Name = "Reason For Visit")]
        public VisitReason ReasonForVisit { get; set; }
    }
}
