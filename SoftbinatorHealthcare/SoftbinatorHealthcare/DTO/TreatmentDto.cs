using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftbinatorHealthcare.DTO
{
    public class TreatmentDto
    {
        public long TreatmentID { get; set; }
        public String DiseaseName { get; set; }
        public String Medication { get; set; }
    }
}
