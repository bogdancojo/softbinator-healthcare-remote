using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SoftbinatorHealthcare.Models
{
    public class Disease
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long DiseaseID { get; set; }
        public String DiseaseName { get; set; }
        public String Symptom1 { get; set; }
        public String Symptom2 { get; set; }
        public String Symptom3 { get; set; }
        public String Symptom4 { get; set; }
        public String Symptom5 { get; set; }
        public String DiseaseType { get; set; }
        public String RiskFactor { get; set; }

        public virtual Treatment Treatment { get; set; }


    }
}
