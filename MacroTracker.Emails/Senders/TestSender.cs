using MacroTracker.Emails.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MacroTracker.Emails.Senders
{
    public class TestSender : IEmailSender
    {
        public string Body { get; set; }
        public string Subject { get; set; }
        public string ToEmail { get; set; }

        public void Send() => Console.WriteLine($"Sending an email to {ToEmail}, subject: {Subject}, body: {Body}");
    }
}
