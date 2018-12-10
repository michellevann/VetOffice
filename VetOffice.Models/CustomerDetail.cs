using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetOffice.Data;

namespace VetOffice.Models
{
    public class CustomerDetail
    {
        public int CustomerId { get; set; }
        [Display(Name = "Name")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
        [Required]
        public string PetName { get; set; }
        [Required]
        public PetType TypeOfPet { get; set; }
        [Required]
        public PetAge AgeOfPet { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + ", " + LastName;
            }
        }
        public override string ToString() => $"[{CustomerId}] {FirstName} {StreetAddress} {City} {State} {ZipCode}";
    }
}

