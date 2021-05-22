using SoftbinatorHealthcare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftbinatorHealthcare.Repository
{
    public interface IPacientRepository<Pacient>
    {
        IEnumerable<Pacient> GetAll();
        Pacient Get(long id);
        void Add(Pacient pacient);
        void Update(Pacient pacient, Pacient _pacient);
        void Delete(Pacient pacient);
    }
}
