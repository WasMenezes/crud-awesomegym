using AwesomeGym.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AwesomeGym.Persistence.Configurations
{
    public class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasMany(u => u.Clients)
                .WithOne(a => a.Unit)
                .HasForeignKey(a => a.IdUnit)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.Coachs)
                .WithOne(a => a.Unit)
                .HasForeignKey(a => a.IdUnit)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.Machines)
                .WithOne(a => a.Unit)
                .HasForeignKey(a => a.IdUnit)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
