using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftbinatorHealthcare.DTO;
using SoftbinatorHealthcare.Entities;
using SoftbinatorHealthcare.Models.DataManager;
using SoftbinatorHealthcare.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftbinatorHealthcare.Controllers
{
    [Route("api/doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository<Doctor> doctorRepository;
        private readonly IMapper mapper;

        public DoctorController(IDoctorRepository<Doctor> repo, IMapper _mapper)
        {
            doctorRepository = repo;
            mapper = _mapper;
        }

        // GET: api/doctor
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Doctor> doctor = doctorRepository.GetAll();
            return Ok(mapper.Map<IEnumerable<DoctorDto>>(doctor));
        }

        [HttpGet]
        [Route("bestdoctor")]
        public IActionResult GetBest()
        {
            String bestDoctor = doctorRepository.GetBestDoctor();
            return Ok(bestDoctor);
        }

        // GET: api/doctor/id
        [HttpGet("{id}", Name = "Getdoctor")]
        public IActionResult Get(long id)
        {
            Doctor doctor = doctorRepository.Get(id);

            if (doctorRepository == null)
            {
                return NotFound("Doctor not found!");
            }

            return Ok(mapper.Map<DoctorDto>(doctor));
        }

        //POST: api/doctor
        [HttpPost]
        public IActionResult Post([FromBody] DoctorDto doctorDto)
        {
            var doctor = mapper.Map<Doctor>(doctorDto);
            if (doctor == null)
            {
                return BadRequest("Doctor is null!");
            }
            doctorRepository.Add(doctor);
            return CreatedAtRoute("Getdoctor", new { Id = doctor.DoctorID }, doctor);
        }

        //PUT : api/pacient
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] DoctorDto doctorDto)
        {
            var doctor = mapper.Map<Doctor>(doctorDto);
            if (doctor == null)
            {
                return BadRequest("Doctor is null.");
            }
            Doctor doctorToUpdate = doctorRepository.Get(id);
            if (doctorToUpdate == null)
            {
                return NotFound("Doctor could not be found!");
            }

            doctorRepository.Update(doctorToUpdate, doctor);
            return NoContent();
        }
        //DELETE: api/pacient/id
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Doctor doctor = doctorRepository.Get(id);
            if (doctor == null)
            {
                return NotFound("Inserted doctor could not be found!");
            }

            doctorRepository.Delete(doctor);
            return NoContent();
        }
    }
}
