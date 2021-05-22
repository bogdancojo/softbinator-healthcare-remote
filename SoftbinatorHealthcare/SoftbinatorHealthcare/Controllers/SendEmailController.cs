using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public SendEmailController(IEmailSender _emailSender)
        {
            emailSender = _emailSender;
        }

        public int FromBody { get; private set; }

        [HttpGet]
        public IActionResult Get([FromBody] Treatment treatment)
        {
            var message = new Message(new string[] { "bogdan.cojocaru97@icloud.com" }, treatment);
            emailSender.SendEmail(message);
            return NoContent();
        }
    }
}
