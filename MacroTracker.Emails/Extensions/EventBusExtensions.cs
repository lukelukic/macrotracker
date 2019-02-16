using EventBus;
using EventBus.Events;
using MacroTracker.Emails.Interfaces;
using MacroTracker.Emails.MailHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MacroTracker.Emails.Extensions
{
    public static class EventBusExtensions
    {
        public static void ManageSubscriptions(this IEventBus bus, IEmailSender sender)
        {
            bus.Subscribe<UserRegisteredEvent>("mail-user-registered", e =>
            {
                var handler = new UserRegisteredEventMailHandler(e);
                handler.Handle(sender);
            });

            bus.Subscribe<UserDeactivatedEvent>("mail-user-deactivated", e =>
            {
                var handler = new UserDeactivatedEventMailHandler(e);
                handler.Handle(sender);
            });
        }
    }
}
