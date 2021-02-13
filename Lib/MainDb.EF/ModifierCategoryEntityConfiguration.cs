﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MainDB.Entities;

namespace MainDB.EF
{
    public sealed class ModifierCategoryEntityConfiguration : IEntityTypeConfiguration<ModifierCategoryRecord>
    {
        public void Configure(EntityTypeBuilder<ModifierCategoryRecord> builder)
        {
            builder.HasKey(c => c.ID);
            builder.Property(c => c.ID).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).HasMaxLength(50);
            builder.HasIndex(c => new { c.AppID, c.Name }).IsUnique();
            builder
                .HasOne<AppRecord>()
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(c => c.AppID);
            builder.ToTable("ModifierCategories");
        }
    }
}
