using System;

namespace MacroTracker.Users.Application.Exceptions
{
    public class EntityAlreadyExists : Exception
    {
        public EntityAlreadyExists()
        {
        }

        public EntityAlreadyExists(string message) : base(message)
        {
        }
    }
}