using System.Collections.Generic;

namespace MacroTracker.Users.Domain.Entities
{
    public class Trainer : User
    {
        public virtual ICollection<TrainerUser> TrainerUsers { get; set; }
        public virtual ICollection<TrainingRequest> RecievedRequests { get; set; }
    }
}