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
    [Route("api/disease")]
    [ApiController]
    public class DiseaseController : ControllerBase
    {
        private readonly IDiseaseRepository<Disease> diseaseRepository;
        private readonly IMapper mapper;

        public DiseaseController(IDiseaseRepository<Disease> repo, IMapper _mapper)
        {
            diseaseRepository = repo;
            mapper = _mapper;
        }

        // GET: api/disease
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Disease> disease = diseaseRepository.GetAll();
            return Ok(mapper.Map<IEnumerable<DiseaseDto>>(disease));
        }

        //GET: api/disease/id
        [HttpGet("{id}", Name = "Getdisease")]
        public IActionResult Get(long id)
        {
            Disease disease = diseaseRepository.Get(id);
            if(disease == null)
            {
                return NotFound("Disease not found!");
            }

            return Ok(mapper.Map<DiseaseDto>(disease));
        }

        //POST: api/disease
        [HttpPost]
        public IActionResult Post([FromBody] DiseaseDto diseaseDto)
        {
            var disease = mapper.Map<Disease>(diseaseDto);
            if (disease == null)
            {
                return BadRequest("Disease is null!");
            }
            diseaseRepository.Add(disease);
            return CreatedAtRoute("Getdisease", new { Id = disease.DiseaseID }, disease);
        }

        //PUT : api/disease
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] DiseaseDto diseaseDto)
        {
            var disease = mapper.Map<Disease>(diseaseDto);
            if (disease == null)
            {
                return BadRequest("Inserted disease is null.");
            }
            Disease diseaseToUpdate = diseaseRepository.Get(id);
            if (diseaseToUpdate == null)
            {
                return NotFound("Disease could not be found!");
            }
            diseaseRepository.Update(diseaseToUpdate,disease);
            return NoContent();
        }

        //DELETE: api/disease/id
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Disease disease = diseaseRepository.Get(id);
            if(disease == null)
            {
                return NotFound("Inserted disease could not be found!");
            }

            diseaseRepository.Delete(disease);
            return NoContent();
        }

    }
}
