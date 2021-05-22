using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SoftbinatorHealthcare.DTO
{
    public class DoctorDto
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
    }
}
