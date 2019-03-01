using FluentAssertions;
using MacroTracker.Emails.Interfaces;
using MacroTracker.Emails.Options;
using MacroTracker.Emails.Senders;
using System;
using Xunit;

namespace Emails.Tests
{
    public class EmailTests
    {
        [Fact]
        public void SmtpMailSenderDoesntThrowWException()
        {
            IEmailSender sender = new SmtpMailSender(new EmailOptions
            {
                FromEmail = "luka.lukic@ict.edu.rs",
                FromName = "Luka Lukic",
                FromPassword = "qwe123LL",
                Host = "smtp.gmail.com",
                Port = 587
            })
            {
                Body = "test 123",
                Subject = "Test case",
                ToEmail = "luka.lukic@ict.edu.rs"
            };

            Action action = () => sender.Send();
            action.Should().NotThrow();
        }

        [Fact]
        public void TestMailSenderDoesntThrowException()
        {
            IEmailSender sender = new TestSender();
            sender.Subject = "Test123";
            sender.ToEmail = "luka.lukic@ict.edu.rs";
            sender.Body = "Message to send.";

            Action action = () => sender.Send();
            action.Should().NotThrow();
        }
    }
}