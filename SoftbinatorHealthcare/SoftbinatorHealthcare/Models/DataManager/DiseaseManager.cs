using SoftbinatorHealthcare.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftbinatorHealthcare.Models.DataManage
{
    public class DiseaseManager : IDiseaseRepository<Disease>
    {
        readonly HealthcareContext healthcareContext;

        public DiseaseManager(HealthcareContext context)
        {
            healthcareContext = context;
        }

        public IEnumerable<Disease> GetAll()
        {
            return healthcareContext.Diseases.ToList();
        }

        public Disease Get(long id)
        {
            return healthcareContext.Diseases.FirstOrDefault(d => d.DiseaseID == id);
        }

        public void Add(Disease disease)
        {
            healthcareContext.Diseases.Add(disease);
            healthcareContext.SaveChanges();
        }

        public void Update(Disease disease, Disease updateDisease)
        {
            disease.DiseaseName = updateDisease.DiseaseName;
            disease.Symptom1 = updateDisease.Symptom1;
            disease.Symptom2 = updateDisease.Symptom2;
            disease.Symptom3 = updateDisease.Symptom3;
            disease.Symptom4 = updateDisease.Symptom4;
            disease.Symptom5 = updateDisease.Symptom5;
            disease.DiseaseType = updateDisease.DiseaseType;
            disease.RiskFactor = updateDisease.RiskFactor;
            healthcareContext.SaveChanges();
        }

        public void Delete(Disease removedDisease)
        {
            healthcareContext.Diseases.Remove(removedDisease);
            healthcareContext.SaveChanges();
        }

    }
    
}
