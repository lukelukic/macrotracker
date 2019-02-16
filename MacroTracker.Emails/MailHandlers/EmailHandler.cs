using EventBus;
using MacroTracker.Emails.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MacroTracker.Emails.MailHandlers
{
    public abstract class EmailHandler<TEvent> where TEvent : IEvent
    {
        protected readonly TEvent _event;

        protected EmailHandler(TEvent @event) => _event = @event;

        public string QueueName => GetType().Name;

        protected abstract string Body { get; }
        protected abstract string Subject { get; }
        protected abstract string ToEmail { get; }

        public virtual void Handle(IEmailSender sender)
        {
            sender.Body = Body;
            sender.Subject = Subject;
            sender.ToEmail = ToEmail;
            sender.Send();
        }
    }
}
