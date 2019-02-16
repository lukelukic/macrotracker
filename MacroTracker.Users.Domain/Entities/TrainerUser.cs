using MacroTracker.Users.Domain.Entities;
using System;

namespace MacroTracker.Users.Domain
{
    public class TrainerUser
    {
        public Guid TrainerId { get; set; }
        public Guid UserId { get; set; }

        public virtual Trainer Trainer { get; set; }
        public virtual User User { get; set; }
    }
}