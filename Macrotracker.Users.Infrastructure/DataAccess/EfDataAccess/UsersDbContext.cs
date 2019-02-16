using Macrotracker.Users.Infrastructure.DataAccess.EfDataAccess;
using Macrotracker.Users.Infrastructure.DataAccess.EfDataAccess.EntityConfigurations;
using MacroTracker.Users.Domain;
using MacroTracker.Users.Domain.Entities;
using MacroTracker.Users.Infrastructure.EntityConfigurations;
using MacroTracker.Users.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MacroTracker.Users.Infrastructure
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new TrainerConfiguration());
            modelBuilder.ApplyConfiguration(new TrainingRequestConfiguration());
            modelBuilder.ConfigureJoinEntities();

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries();
            entries.SetCreatedUpdatedAtDates();
            return base.SaveChanges();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<TrainingRequest> TrainingRequests { get; set; }
    }
}