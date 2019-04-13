using System;
using System.Runtime.Serialization;

namespace MacroTracker.Users.Application
{
    public class EntityInactiveException : Exception
    {
        public EntityInactiveException(string message) : base(message){}
    }
}