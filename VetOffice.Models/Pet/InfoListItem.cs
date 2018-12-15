using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetOffice.Models
{
    public class InfoListItem
    {
        [Key]
        public int CustomerId { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }
     
        public List<PetListItem> Pets { get; set; }
    }
}
