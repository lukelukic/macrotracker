using MacroTracker.Users.Domain;
using MacroTracker.Users.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Macrotracker.Users.Infrastructure.DataAccess.EfDataAccess.EntityConfigurations
{
    public class TrainerConfiguration : IEntityTypeConfiguration<Trainer>
    {
        public void Configure(EntityTypeBuilder<Trainer> builder)
        {
            builder.HasBaseType<User>();
        }
    }
}