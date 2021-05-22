using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftbinatorHealthcare.DTO;
using SoftbinatorHealthcare.Email;
using SoftbinatorHealthcare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftbinatorHealthcare.Controllers
{
    [Route("api/sendemail")]
    [ApiController]
    public class SendEmailController : ControllerBase
    {
        private readonly IEmailSender emailSender;
        private readonly IMapper mapper;
        public SendEmailController(IEmailSender _emailSender, IMapper _mapper)
        {
            emailSender = _emailSender;
            mapper = _mapper;
        }

        public int FromBody { get; private set; }

        [Authorize]
        [HttpGet]
        public IActionResult Get([FromBody] TreatmentDto treatmentDto)
        {
            var treatment = mapper.Map<Treatment>(treatmentDto);
            var message = new Message(new string[] { "bogdan.cojocaru97@icloud.com" }, treatment);
            emailSender.SendEmail(message);
            return NoContent();
        }
    }
}
