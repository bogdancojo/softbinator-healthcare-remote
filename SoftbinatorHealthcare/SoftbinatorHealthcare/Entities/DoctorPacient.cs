using SoftbinatorHealthcare.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SoftbinatorHealthcare.Entities
{
    public class DoctorPacient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public long DoctorID { get; set; }
        public Doctor Doctor { get; set; }

        public long PacientID { get; set; }
        public Pacient Pacient { get; set; }
     
    }
}
