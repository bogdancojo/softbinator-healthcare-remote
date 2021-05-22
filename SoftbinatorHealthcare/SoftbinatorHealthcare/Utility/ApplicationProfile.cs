using SoftbinatorHealthcare.DTO;
using SoftbinatorHealthcare.Entities;
using SoftbinatorHealthcare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftbinatorHealthcare.Utility
{
    public class ApplicationProfile : AutoMapper.Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Pacient, PacientDto>().
                ReverseMap();
            CreateMap<Doctor, DoctorDto>().
                ReverseMap();
            CreateMap<Disease, DiseaseDto>().
                ReverseMap();
            CreateMap<Treatment, TreatmentDto>().
                ReverseMap();
        }
    }
}
