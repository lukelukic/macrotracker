using MacroTracker.Emails.Interfaces;
using MacroTracker.Emails.Options;
using MacroTracker.Emails.Senders;
using NUnit.Framework;

namespace Emails.Tests
{
    [TestFixture]
    public class EmailTests
    {
        [Test]
        public void TestMailSending()
        {
            IEmailSender sender = new SmtpMailSender(new EmailOptions
            {
                FromEmail = "luka.lukic@ict.edu.rs",
                FromName = "Luka Lukic",
                FromPassword = "qwe123LL",
                Host = "smtp.gmail.com",
                Port = 587
            });

            sender.Body = "test 123";
            sender.Subject = "Test case";
            sender.ToEmail = "luka.lukic@ict.edu.rs";

            sender.Send();
            Assert.AreEqual(true, true);
        }
    }
}