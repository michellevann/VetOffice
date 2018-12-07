﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetOffice.Data;

namespace VetOffice.Models
{
    public class PetListItem
    {
        [Display(Name = "Pet Name")]
        public string PetName { get; set; }
        [Display(Name = "Type of Pet")]
        public PetType TypeOfPet { get; set; }
        [Display(Name = "Age of Pet")]
        public PetAge AgeOfPet { get; set; }
    }
}
