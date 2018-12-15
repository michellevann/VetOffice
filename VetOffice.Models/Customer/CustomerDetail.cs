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
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        [Display(Name = "Apt #")]
        public string Apt { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
        [Phone]
        public string Phone { get; set; }
        public bool CanText { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        public override string ToString() => $"[{CustomerId}] {FullName} {StreetAddress} {City} {State} {ZipCode}";
    }
}

