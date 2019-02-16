using MacroTracker.Users.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Macrotracker.Users.Infrastructure.DataAccess.EfDataAccess.EntityConfigurations
{
    public class TrainingRequestConfiguration : IEntityTypeConfiguration<TrainingRequest>
    {
        public void Configure(EntityTypeBuilder<TrainingRequest> builder)
        {
            builder.HasQueryFilter(r => r.IsActive);
            builder.HasOne(r => r.User).WithMany(u => u.SentRequests);
            builder.HasOne(r => r.Trainer).WithMany(t => t.RecievedRequests).OnDelete(DeleteBehavior.Restrict);
        }
    }
}