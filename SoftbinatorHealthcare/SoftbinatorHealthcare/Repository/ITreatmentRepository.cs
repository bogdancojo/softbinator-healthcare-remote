using SoftbinatorHealthcare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftbinatorHealthcare.Repository
{
    public interface ITreatmentRepository<Treatment>
    {
        IEnumerable<Treatment> GetAll();
        Treatment Get(long id);
        bool Add(Treatment treatment);
        void Update(Treatment treatment, Treatment _treatment);
        void Delete(Treatment treatment);
    }
  
}
