using System;

namespace EventBus.Events
{
    public class UserRegisteredEvent : IEvent
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateRegistered { get; set; }
    }
}