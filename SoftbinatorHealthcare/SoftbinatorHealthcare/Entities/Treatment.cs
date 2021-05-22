using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SoftbinatorHealthcare.Models
{
    public class Treatment
    {
        [ForeignKey("Disease")]
        public long TreatmentID { get; set; }
        public String DiseaseName { get; set; }
        public String Medication { get; set; }
        public DateTime StartDate { get; set; }

        public virtual Disease Disease { get; set; }

    }
}
