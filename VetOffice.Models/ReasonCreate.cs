using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetOffice.Data;

namespace VetOffice.Models
{
    public class ReasonCreate
    {
        [Required]
        [Display(Name = "Reason For Visit")]
        public VisitReason ReasonForVisit { get; set; }
    }
}
