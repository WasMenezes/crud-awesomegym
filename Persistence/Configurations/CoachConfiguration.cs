using AwesomeGym.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AwesomeGym.Persistence.Configurations
{
    public class CoachConfiguration : IEntityTypeConfiguration<Coach>
    {
        public void Configure(EntityTypeBuilder<Coach> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasMany(c => c.Clients)
                .WithOne(a => a.Coach)
                .HasForeignKey(a => a.IdCoach)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
