using MacroTracker.Users.Domain;
using MacroTracker.Users.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MacroTracker.Users.Infrastructure.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasDiscriminator<string>("user_type")
                .HasValue<User>("user")
                .HasValue<Trainer>("trainer");

            builder.Property(u => u.FirstName).HasMaxLength(50);
            builder.Property(u => u.LastName).HasMaxLength(50);
            builder.Property(u => u.Email).HasMaxLength(255);
            builder.Property(u => u.Password).HasMaxLength(255);

            builder.HasQueryFilter(r => r.IsActive);
        }
    }
}