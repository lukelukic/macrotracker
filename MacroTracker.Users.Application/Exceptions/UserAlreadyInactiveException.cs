using System;
using System.Runtime.Serialization;

namespace MacroTracker.Users.Application
{
    [Serializable]
    public class UserAlreadyInactiveException : Exception
    {
        public UserAlreadyInactiveException()
        {
        }

        public UserAlreadyInactiveException(string message) : base(message)
        {
        }

        public UserAlreadyInactiveException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UserAlreadyInactiveException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}