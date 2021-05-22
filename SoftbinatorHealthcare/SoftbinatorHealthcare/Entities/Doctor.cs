﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SoftbinatorHealthcare.Entities
{
    public class Doctor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long DoctorID { get; set; }
        [Required(ErrorMessage = "FirstName is required")]
        [StringLength(60, ErrorMessage = "FirstName can't be longer than 60 characters")]
        public String FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        [StringLength(60, ErrorMessage = "LastName can't be longer than 60 characters")]
        public String LastName { get; set; }
        public long Sallary { get; set; }

        // Navigation properties
        public List<DoctorPacient> DoctorPacients { get; set; }
    }
}
