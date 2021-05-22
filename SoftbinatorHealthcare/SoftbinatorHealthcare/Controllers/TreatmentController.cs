using AutoMapper;
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
    [Route("api/treatment")]
    [ApiController]
    public class TreatmentController : ControllerBase
    {
        private readonly ITreatmentRepository<Treatment> treatmentRepository;
        private readonly IMapper mapper;

        public TreatmentController(ITreatmentRepository<Treatment> repo, IMapper _mapper)
        {
            treatmentRepository = repo;
            mapper = _mapper;
        }

        // GET: api/treatment
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Treatment> treatment = treatmentRepository.GetAll();
            return Ok(mapper.Map<IEnumerable<TreatmentDto>>(treatment));
        }

        // GET: api/treatment/id
        [HttpGet("{id}", Name = "Gettreatment")]
        public IActionResult Get(long id)
        {
            Treatment treatment = treatmentRepository.Get(id);

            if (treatment == null)
            {
                return NotFound("Treatment not found!");
            }

            return Ok(mapper.Map<TreatmentDto>(treatment));
        }

        //POST: api/treatment
        [HttpPost]
        public IActionResult Post([FromBody] TreatmentDto treatmentDto)
        {
            var treatment = mapper.Map<Treatment>(treatmentDto);
            if (treatment == null)
            {
                return BadRequest("Treatment is null!");
            }
            bool isTreatmentAdded = treatmentRepository.Add(treatment);
            if (isTreatmentAdded)
            {
                return CreatedAtRoute("Gettreatment", new { Id = treatment.TreatmentID }, treatment);
            }
            else
            {
                return BadRequest("Treatment inserted does not have an assosciated disease!");
            }
            
        }

        //PUT : api/treatment update
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] TreatmentDto treatmentDto)
        {
            var treatment = mapper.Map<Treatment>(treatmentDto);
            if (treatment == null)
            {
                return BadRequest("Treatment is null.");
            }
            Treatment treatmentToUpdate = treatmentRepository.Get(id);
            if (treatmentToUpdate == null)
            {
                return NotFound("Treatment could not be found!");
            }
            
            treatmentRepository.Update(treatmentToUpdate, treatment);
            return NoContent();
        }

        //DELETE: api/treatment/id
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Treatment treatment = treatmentRepository.Get(id);
            if (treatment == null)
            {
                return NotFound("Inserted treatment could not be found!");
            }

            treatmentRepository.Delete(treatment);
            return NoContent();
        }
    }
}
