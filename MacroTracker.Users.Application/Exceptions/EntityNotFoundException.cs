using System;

namespace MacroTracker.Users.Application.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(Guid id, string entityType) : base($"{entityType} with an id of {id} doesn't exist.")
        {
        }
    }
}