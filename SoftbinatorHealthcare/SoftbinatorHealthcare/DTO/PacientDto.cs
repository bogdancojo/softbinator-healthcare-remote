using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftbinatorHealthcare.DTO
{
    public class PacientDto
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Insurance { get; set; }
        public String UnderlyingConditions { get; set; }
    }
}
