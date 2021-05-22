using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftbinatorHealthcare.DTO;
using SoftbinatorHealthcare.Models;
using SoftbinatorHealthcare.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftbinatorHealthcare.Controllers
{
    [Route("api/pacient")]
    [ApiController]
    public class PacientCotroller : ControllerBase
    {
        private readonly IPacientRepository<Pacient> pacientRepository;
        private readonly IMapper mapper;

        public PacientCotroller(IPacientRepository<Pacient> repo, IMapper _mapper)
        {
            pacientRepository = repo;
            mapper = _mapper;
        }

        [Authorize]
        // GET: api/pacient
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Pacient> pacient = pacientRepository.GetAll();
            return Ok(mapper.Map<IEnumerable<PacientDto>>(pacient));
        }

        // GET: api/pacient/id
        [HttpGet("{id}", Name = "Getpacient")]
        public IActionResult Get(long id)
        {
            Pacient pacient = pacientRepository.Get(id);

            if (pacient == null)
            {
                return NotFound("Pacient not found!");
            }

            return Ok(mapper.Map<PacientDto>(pacient));
        }

        //POST: api/pacient add
        [HttpPost]
        public IActionResult Post([FromBody] PacientDto pacientDto)
        {
            var pacient = mapper.Map<Pacient>(pacientDto);
            if (pacient == null)
            {
                return BadRequest("Pacient is null!");
            }
            pacientRepository.Add(pacient);
            return CreatedAtRoute("Getpacient", new { Id = pacient.PacientID }, pacient);
        }

        //PUT : api/pacient update
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] PacientDto pacientDto)
        {
            var pacient = mapper.Map<Pacient>(pacientDto);
            if (pacient == null)
            {
                return BadRequest("Inserted pacient is null.");
            }
            Pacient pacientToUpdate = pacientRepository.Get(id);
            if(pacientToUpdate == null)
            {
                return NotFound("Pacient could not be found!");
            }

            pacientRepository.Update(pacientToUpdate, pacient);
            return NoContent();
        }
        //DELETE: api/pacient/id
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Pacient pacient = pacientRepository.Get(id);
            if (pacient == null)
            {
                return NotFound("Inserted pacient could not be found!");
            }

            pacientRepository.Delete(pacient);
            return NoContent();
        }
    }
}
