using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetOffice.Data
{
    public enum VisitReason
    {
        [Display(Name ="Annual Checkup")]
        AnnualCheckup,
        Vaccinations,
        Grooming,
        [Display(Name ="Spay/Neuter")]
        SpayNeuter,
        [Display(Name = "Labwork/Tests")]
        LabworkTests,
        Declawing
    }
    public class Reason
    {
        [Key]
        public int VisitId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public VisitReason ReasonForVisit { get; set; }
    }
}
