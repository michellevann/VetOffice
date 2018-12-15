using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetOffice.Data;

namespace VetOffice.Models
{
    public class CustomerEdit
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string StreetAddress { get; set; }
        public string Apt { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        [Phone]
        public string Phone { get; set; }
        public bool CanText { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
