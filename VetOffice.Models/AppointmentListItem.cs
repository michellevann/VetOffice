﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetOffice.Models
{
    public class AppointmentListItem
    {
        [Display(Name = "Next Appointment")]
        public DateTime NextAppt { get; set; }
    }
}
