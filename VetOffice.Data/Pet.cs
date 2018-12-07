using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetOffice.Data
{
    public enum PetType
    {
        Cat,
        Dog
    }

    public enum PetAge
    {
        [Display(Name = "Less than 1 year")]
        LessThan1Year,
        [Display(Name = "1 year")]
        One,
        [Display(Name = "2 years")]
        Two,
        [Display(Name = "3 years")]
        Three,
        [Display(Name = "4 years")]
        Four,
        [Display(Name = "5 years")]
        Five,
        [Display(Name = "6 years")]
        Six,
        [Display(Name = "7 years")]
        Seven,
        [Display(Name = "8 years")]
        Eight,
        [Display(Name = "9 years")]
        Nine,
        [Display(Name = "10 or more")]
        TenOrMore
    }

    public class Pet
    {
        [Key]
        public int PetId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string PetName { get; set; }
        [Required]
        public PetType TypeOfPet { get; set; }
        [Required]
        public PetAge AgeOfPet { get; set; }
    }

}
