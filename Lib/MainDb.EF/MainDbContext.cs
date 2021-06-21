﻿using MainDB.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using XTI_Core;
using XTI_Core.EF;

namespace MainDB.EF
{
    public sealed class MainDbContext : DbContext, IMainDbContext
    {
        private readonly UnitOfWork unitOfWork;

        public MainDbContext(DbContextOptions<MainDbContext> options)
            : base(options)
        {
            Users = new EfDataRepository<AppUserRecord>(this);
            Sessions = new EfDataRepository<AppSessionRecord>(this);
            Requests = new EfDataRepository<AppRequestRecord>(this);
            Events = new EfDataRepository<AppEventRecord>(this);
            Apps = new EfDataRepository<AppRecord>(this);
            Versions = new EfDataRepository<AppVersionRecord>(this);
            Roles = new EfDataRepository<AppRoleRecord>(this);
            UserRoles = new EfDataRepository<AppUserRoleRecord>(this);
            ResourceGroups = new EfDataRepository<ResourceGroupRecord>(this);
            ResourceGroupRoles = new EfDataRepository<ResourceGroupRoleRecord>(this);
            Resources = new EfDataRepository<ResourceRecord>(this);
            ResourceRoles = new EfDataRepository<ResourceRoleRecord>(this);
            ModifierCategories = new EfDataRepository<ModifierCategoryRecord>(this);
            ModifierCategoryAdmins = new EfDataRepository<ModifierCategoryAdminRecord>(this);
            Modifiers = new EfDataRepository<ModifierRecord>(this);
            UserModifiers = new EfDataRepository<AppUserModifierRecord>(this);
            unitOfWork = new UnitOfWork(this);
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

        public DataRepository<AppUserRecord> Users { get; }
        public DataRepository<AppSessionRecord> Sessions { get; }
        public DataRepository<AppRequestRecord> Requests { get; }
        public DataRepository<AppEventRecord> Events { get; }
        public DataRepository<AppRecord> Apps { get; }
        public DataRepository<AppVersionRecord> Versions { get; }
        public DataRepository<AppRoleRecord> Roles { get; }
        public DataRepository<AppUserRoleRecord> UserRoles { get; }
        public DataRepository<ResourceGroupRecord> ResourceGroups { get; }
        public DataRepository<ResourceGroupRoleRecord> ResourceGroupRoles { get; }
        public DataRepository<ResourceRecord> Resources { get; }
        public DataRepository<ResourceRoleRecord> ResourceRoles { get; }
        public DataRepository<ModifierCategoryRecord> ModifierCategories { get; }
        public DataRepository<ModifierCategoryAdminRecord> ModifierCategoryAdmins { get; }
        public DataRepository<ModifierRecord> Modifiers { get; }
        public DataRepository<AppUserModifierRecord> UserModifiers { get; }

        public Task Transaction(Func<Task> action) => unitOfWork.Execute(action);

    }
}
