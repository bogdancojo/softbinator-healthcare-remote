using Microsoft.EntityFrameworkCore;
using SoftbinatorHealthcare.Entities;
using SoftbinatorHealthcare.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftbinatorHealthcare.Models.DataManager
{
    public class DoctorManager : IDoctorRepository<Doctor>
    {
        readonly HealthcareContext healthcareContext;

        public DoctorManager(HealthcareContext context)
        {
            healthcareContext = context;
        }

        public IEnumerable<Doctor> GetAll()
        {
            return healthcareContext.Doctors.ToList();
        }

        public Doctor Get(long id)
        {
            return healthcareContext.Doctors.FirstOrDefault(d => d.DoctorID == id);
        }

        public void Add(Doctor doctor)
        {
            healthcareContext.Doctors.Add(doctor);
            healthcareContext.SaveChanges();
        }
        public void Update(Doctor doctor, Doctor updateDcotor)
        {
            doctor.FirstName = updateDcotor.FirstName;
            doctor.LastName = updateDcotor.LastName;
            healthcareContext.SaveChanges();
        }

        public void Delete(Doctor doctor)
        {
            healthcareContext.Doctors.Remove(doctor);
            healthcareContext.SaveChanges();
        }

        public String GetBestDoctor()
        {
            long bestDoctorId = healthcareContext.DoctorPacients.GroupBy(x => x.DoctorID).OrderByDescending(x => x.Count())
                .Select(x => x.Key).FirstOrDefault();
            Doctor doctor = healthcareContext.Doctors.Find(bestDoctorId);

            return doctor.FirstName + " " + doctor.LastName;
        }
    }
}
