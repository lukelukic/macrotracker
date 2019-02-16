using System;

namespace MacroTracker.Users.Domain.Entities
{
    public class TrainingRequest : Entity
    {
        public Guid TrainerId { get; set; }
        public Guid UserId { get; set; }

        public virtual User User { get; set; }
        public virtual Trainer Trainer { get; set; }
    }
}