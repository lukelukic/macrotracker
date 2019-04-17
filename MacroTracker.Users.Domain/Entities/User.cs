using MacroTracker.Users.Domain.Entities;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace MacroTracker.Users.Domain
{
    [ExcludeFromCodeCoverage]
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }

        public virtual ICollection<TrainerUser> UserTrainers { get; set; }
        public virtual ICollection<TrainingRequest> SentRequests { get; set; }
    }
}