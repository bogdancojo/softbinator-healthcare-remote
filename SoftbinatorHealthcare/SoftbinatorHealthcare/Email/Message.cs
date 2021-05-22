using MimeKit;
using SoftbinatorHealthcare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftbinatorHealthcare.Email
{
    public class Message
    {
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public Message(IEnumerable<String> to, Treatment treatment)
        {
            To = new List<MailboxAddress>();
            To.AddRange(to.Select(x => new MailboxAddress(x)));
            Subject = "Automated prescription";
            string part1 = "Prescription for " + treatment.DiseaseName.ToString() + ":\n";
            string part2 = treatment.Medication;
            Content = part1 + part2;

        }
    }
}
