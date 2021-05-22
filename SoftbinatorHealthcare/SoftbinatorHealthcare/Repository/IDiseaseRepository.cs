using SoftbinatorHealthcare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftbinatorHealthcare.Repository
{
    public interface IDiseaseRepository<Disease>
    {
        IEnumerable<Disease> GetAll();
        Disease Get(long id);
        void Add(Disease disease);
        void Update(Disease disease, Disease updateDisease);
        void Delete(Disease disease);
    }
}
