using SoftbinatorHealthcare.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftbinatorHealthcare.Models.DataManage
{
    
    public class PacientManager : IPacientRepository<Pacient>
    {
        readonly HealthcareContext healthcareContext;

        public PacientManager(HealthcareContext Context)
        {
            healthcareContext = Context;
        }

        public IEnumerable<Pacient> GetAll()
        {
            return healthcareContext.Pacients.ToList();
        }

        public Pacient Get(long id)
        {
            return healthcareContext.Pacients.FirstOrDefault(p => p.PacientID == id);
        }

        public void Add(Pacient pacient)
        {
            healthcareContext.Pacients.Add(pacient);
            healthcareContext.SaveChanges();
        }
        public void Update(Pacient pacient, Pacient updatePacient)
        {
            pacient.FirstName = updatePacient.FirstName;
            pacient.LastName = updatePacient.LastName;
            pacient.DateOfBirth = updatePacient.DateOfBirth;
            pacient.Insurance = updatePacient.Insurance;
            pacient.UnderlyingConditions = updatePacient.UnderlyingConditions;
            healthcareContext.SaveChanges();
        }

        public void Delete(Pacient deletePacient)
        {
            healthcareContext.Pacients.Remove(deletePacient);
            healthcareContext.SaveChanges();
        }
    }
}
