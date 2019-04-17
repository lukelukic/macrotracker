using MacroTracker.Users.Domain.Entities;
using System;
using System.Diagnostics.CodeAnalysis;

namespace MacroTracker.Users.Domain
{
    public class TrainerUser
    {
        [ExcludeFromCodeCoverage]
        public Guid TrainerId { get; set; }
        public Guid UserId { get; set; }

        public virtual Trainer Trainer { get; set; }
        public virtual User User { get; set; }
    }
}