using MacroTracker.Users.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;

namespace MacroTracker.Users.Infrastructure.Extensions
{
    public static class ContextExtensions
    {
        public static void SetCreatedUpdatedAtDates(this IEnumerable<EntityEntry> entries)
        {
            foreach (var entry in entries)
            {
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            e.UpdatedAt = DateTime.Now;
                            break;

                        case EntityState.Added:
                            e.CreatedAt = DateTime.Now;
                            e.IsActive = true;
                            break;
                    }
                }
            }
        }

        public static void ConfigureJoinEntities(this ModelBuilder builder)
        {
            builder.Entity<TrainerUser>().HasKey(tu => new { tu.TrainerId, tu.UserId });

            builder.Entity<TrainerUser>()
                .HasOne(tu => tu.Trainer)
                .WithMany(t => t.TrainerUsers)
                .HasForeignKey(tu => tu.TrainerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<TrainerUser>()
                .HasOne(tu => tu.User)
                .WithMany(t => t.UserTrainers)
                .HasForeignKey(tu => tu.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}