using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetOffice.Data;

namespace VetOffice.Models
{
    public class CustPetApptCreate
    {
        public int CustPetApptId { get; set; }
        public CustomerCreate Cust { get; set; }
        public PetCreate Pet { get; set; }
        public AppointmentCreate Appt { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
        [Required]
        [Display(Name = "Pet Name")]
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
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Next Appointment")]
        public DateTime NextAppt { get; set; }
    }
}

