using EventBus.Events;
using MacroTracker.Emails.MailHandlers;
using MacroTracker.Emails.Senders;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using Moq;
using MacroTracker.Emails.Interfaces;

namespace Emails.Tests
{
    public class TestEmailHandlers
    {
        [Fact]
        public void UserDeactivatedEventMailHandlerCallsSendMethod()
        {
            var @event = new UserDeactivatedEvent
            {
                Email = "luka.lukic@quadro-tnation.com",
                FirstName = "Luka",
                LastName = "Lukic"
            };
            var handler = new UserDeactivatedEventMailHandler(@event);

            var mock = new Mock<IEmailSender>();

            handler.Handle(mock.Object);

            mock.Verify(m => m.Send(), Times.Once());
        }

        [Fact]
        public void UserRegisteredEventMailHandlerCallsSendMethod()
        {
            var @event = new UserRegisteredEvent
            {
                Email = "luka.lukic@quadro-tnation.com",
                FirstName = "Luka",
                LastName = "Lukic",
                DateRegistered = DateTime.Now,
                Username = "luke"
            };
            var handler = new UserRegisteredEventMailHandler(@event);

            var mock = new Mock<IEmailSender>();

            handler.Handle(mock.Object);

            mock.Verify(m => m.Send(), Times.Once());
        }
    }
}
