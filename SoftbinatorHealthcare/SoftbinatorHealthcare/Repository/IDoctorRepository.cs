using SoftbinatorHealthcare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftbinatorHealthcare.Repository
{
    public interface IDoctorRepository<Doctor>
    {
        IEnumerable<Doctor> GetAll();
        Doctor Get(long id);
        void Add(Doctor doctor);
        void Update(Doctor doctor, Doctor _doctor);
        void Delete(Doctor doctor);
        String GetBestDoctor();
    }
}
