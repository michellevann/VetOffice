using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetOffice.Data
{
    public enum VisitReason
    {
        [Display(Name = "Annual Checkup")]
        AnnualCheckup,
        Vaccinations,
        Grooming,
        [Display(Name = "Spay/Neuter")]
        SpayNeuter,
        [Display(Name = "Labwork/Tests")]
        LabworkTests,
        Declawing,
        Deworming,
        [Display(Name = "Emergency Services")]
        EmergencyServices
    }

    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        public Guid OwnerId { get; set; }
        public int CustomerId { get; set; }
        [Required]
        public DateTime NextAppt { get; set; }
        public string ApptTime { get; set; }
        [Required]
        public VisitReason ReasonForVisit { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
