﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MainDB.Entities;

namespace MainDB.EF
{
    public sealed class ModifierEntityConfiguration : IEntityTypeConfiguration<ModifierRecord>
    {
        public void Configure(EntityTypeBuilder<ModifierRecord> builder)
        {
            builder.HasKey(m => m.ID);
            builder.Property(m => m.ID).ValueGeneratedOnAdd();
            builder.Property(m => m.ModKey).HasMaxLength(100);
            builder.HasIndex(m => new { m.CategoryID, m.ModKey }).IsUnique();
            builder.Property(m => m.TargetKey).HasMaxLength(100);
            builder.HasIndex(m => new { m.CategoryID, m.TargetKey }).IsUnique();
            builder
                .HasOne<ModifierCategoryRecord>()
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(m => m.CategoryID);
            builder.ToTable("Modifiers");
        }
    }
}
