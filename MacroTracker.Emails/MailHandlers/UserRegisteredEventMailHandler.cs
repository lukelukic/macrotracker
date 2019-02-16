using EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MacroTracker.Emails.MailHandlers
{
    public class UserRegisteredEventMailHandler : EmailHandler<UserRegisteredEvent>
    {
        public UserRegisteredEventMailHandler(UserRegisteredEvent @event) : base(@event)
        {
        }

        protected override string Body => "Successfull registration!";

        protected override string Subject => "Registration";

        protected override string ToEmail => _event.Email;
    }
}
