using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetOffice.Data;

namespace VetOffice.Models
{
    public class ReasonEdit
    {
        public int ReasonId { get; set; }
        [Required]
        public VisitReason ReasonForVisit { get; set; }
    }
}
