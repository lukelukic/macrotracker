using MacroTracker.Emails.Interfaces;
using MacroTracker.Emails.Options;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace MacroTracker.Emails.Senders
{
    public class SmtpMailSender : IEmailSender
    {
        private readonly EmailOptions _options;
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public SmtpMailSender(EmailOptions options) => _options = options;

        public SmtpMailSender(IOptions<EmailOptions> options) => _options = options.Value;

        public void Send()
        {
            var fromAddress = new MailAddress(_options.FromEmail, _options.FromName);
            var toAddress = new MailAddress(ToEmail, Subject);

            var smtp = new SmtpClient
            {
                Host = _options.Host,
                Port = _options.Port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, _options.FromPassword)
            };

            using (var message = new MailMessage(_options.FromEmail, ToEmail)
            {
                Subject = Subject,
                Body = Body
            })
            {
                smtp.Send(message);
            }
        }
    }
}