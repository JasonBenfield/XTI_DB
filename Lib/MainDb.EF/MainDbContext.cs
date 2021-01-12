﻿using MainDB.Entities;
using Microsoft.EntityFrameworkCore;

namespace MainDB.EF
{
    public sealed class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions options)
            : base(options)
        {
            Users = Set<AppUserRecord>();
            Sessions = Set<AppSessionRecord>();
            Requests = Set<AppRequestRecord>();
            Events = Set<AppEventRecord>();
            Apps = Set<AppRecord>();
            Versions = Set<AppVersionRecord>();
            Roles = Set<AppRoleRecord>();
            UserRoles = Set<AppUserRoleRecord>();
            ResourceGroups = Set<ResourceGroupRecord>();
            ResourceGroupRoles = Set<ResourceGroupRoleRecord>();
            Resources = Set<ResourceRecord>();
            ResourceRoles = Set<ResourceRoleRecord>();
            ModifierCategories = Set<ModifierCategoryRecord>();
            ModifierCategoryAdmins = Set<ModifierCategoryAdminRecord>();
            Modifiers = Set<ModifierRecord>();
            UserModifiers = Set<AppUserModifierRecord>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AppSessionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AppRequestEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AppEventEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AppEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AppVersionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserRoleEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ResourceGroupEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ResourceGroupRoleEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ResourceEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ResourceRoleEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ModifierCategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ModifierCategoryAdminEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ModifierEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserModifierEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AppUserRecord> Users { get; }
        public DbSet<AppSessionRecord> Sessions { get; }
        public DbSet<AppRequestRecord> Requests { get; }
        public DbSet<AppEventRecord> Events { get; }
        public DbSet<AppRecord> Apps { get; }
        public DbSet<AppVersionRecord> Versions { get; }
        public DbSet<AppRoleRecord> Roles { get; }
        public DbSet<AppUserRoleRecord> UserRoles { get; }
        public DbSet<ResourceGroupRecord> ResourceGroups { get; }
        public DbSet<ResourceGroupRoleRecord> ResourceGroupRoles { get; }
        public DbSet<ResourceRecord> Resources { get; }
        public DbSet<ResourceRoleRecord> ResourceRoles { get; }
        public DbSet<ModifierCategoryRecord> ModifierCategories { get; }
        public DbSet<ModifierCategoryAdminRecord> ModifierCategoryAdmins { get; }
        public DbSet<ModifierRecord> Modifiers { get; }
        public DbSet<AppUserModifierRecord> UserModifiers { get; }
    }
}
