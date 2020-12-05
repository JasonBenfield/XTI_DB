﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MainDB.Entities;

namespace MainDB.EF
{
    public sealed class AppEntityConfiguration : IEntityTypeConfiguration<AppRecord>
    {
        public void Configure(EntityTypeBuilder<AppRecord> builder)
        {
            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID).ValueGeneratedOnAdd();
            builder.Property(a => a.Name).HasMaxLength(50);
            builder.HasIndex(a => a.Name).IsUnique();
            builder.Property(a => a.Title)
                .HasMaxLength(100)
                .HasDefaultValue("");
        }
    }
}
