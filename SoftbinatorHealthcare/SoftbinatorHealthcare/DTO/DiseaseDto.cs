using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftbinatorHealthcare.DTO
{
    public class DiseaseDto
    {
        public String DiseaseName { get; set; }
        public String Symptom1 { get; set; }
        public String Symptom2 { get; set; }
        public String Symptom3 { get; set; }
        public String Symptom4 { get; set; }
        public String Symptom5 { get; set; }
        public String DiseaseType { get; set; }
        public String RiskFactor { get; set; }
    }
}
