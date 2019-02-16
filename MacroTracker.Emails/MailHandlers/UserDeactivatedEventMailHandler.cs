using EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MacroTracker.Emails.MailHandlers
{
    public class UserDeactivatedEventMailHandler : EmailHandler<UserDeactivatedEvent>
    {
        public UserDeactivatedEventMailHandler(UserDeactivatedEvent @event) : base(@event)
        {
        }

        protected override string Body => $"Dear {_event.FirstName}, " +
                                            $"</br> You have successfully deactivated your account." +
                                            $"</br></br>" +
                                            $"Best regards, </br> Macrotracker LLC";

        protected override string Subject => "Account deactivation.";

        protected override string ToEmail => _event.Email;
    }
}
