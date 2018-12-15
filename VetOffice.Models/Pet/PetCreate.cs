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
        public int PetId { get; set; }
        public int CustomerId { get; set; }

        [Required]
        [Display(Name = "Pet Name")]
        public string PetName { get; set; }

        [Required]
        [Display(Name = "Type of Pet")]
        public PetType TypeOfPet { get; set; }

        [Required]
        public string Breed { get; set; }

        [Required]
        [Display(Name = "Age of Pet")]
        public PetAge AgeOfPet { get; set; }

        public virtual Customer Customer { get; set; }
    }
}








