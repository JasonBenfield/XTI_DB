using MainDB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MainDB.EF
{
    public sealed class AppRoleEntityConfiguration : IEntityTypeConfiguration<AppRoleRecord>
    {
        public void Configure(EntityTypeBuilder<AppRoleRecord> builder)
        {
            builder.HasKey(r => r.ID);
            builder.Property(r => r.ID).ValueGeneratedOnAdd();
            builder.Property(r => r.Name).HasMaxLength(100);
            builder
                .HasIndex(r => new { r.AppID, r.Name })
                .IsUnique();
            builder
                .HasOne<AppRecord>()
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(r => r.AppID);
            builder.ToTable("Roles");
        }
    }
}
