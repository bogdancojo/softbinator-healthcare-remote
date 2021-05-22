using Microsoft.EntityFrameworkCore;
using SoftbinatorHealthcare.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftbinatorHealthcare.Models.DataManager
{
    public class TreatmentManager : ITreatmentRepository<Treatment>
    {
        private readonly HealthcareContext healthcareContext;

        public TreatmentManager(HealthcareContext _healthcareContext)
        {
            this.healthcareContext = _healthcareContext;
        }
        public IEnumerable<Treatment> GetAll()
        {
            return healthcareContext.Treatments.ToList();
        }
        public Treatment Get(long id)
        {
            return healthcareContext.Treatments.FirstOrDefault(t => t.TreatmentID == id);
        }
        public bool Add(Treatment treatment)
        {
            try
            {
                healthcareContext.Treatments.Add(treatment);
                healthcareContext.SaveChanges();
                return true;
            }
            catch (DbUpdateException exception)
            {
                return false;
            }
            

        }
        public void Update(Treatment treatment, Treatment updateTreatment)
        {
            treatment.TreatmentID = updateTreatment.TreatmentID;
            treatment.DiseaseName = updateTreatment.DiseaseName;
            treatment.Medication = updateTreatment.Medication;
            treatment.StartDate = updateTreatment.StartDate;
            healthcareContext.SaveChanges();
        }
        public void Delete(Treatment treatment)
        {
            healthcareContext.Treatments.Remove(treatment);
            healthcareContext.SaveChanges();
        }
    }
}
