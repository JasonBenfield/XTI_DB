using System;
using System.Threading.Tasks;
using XTI_Core;

namespace MainDB.Entities
{
    public interface IMainDbContext
    {
        DataRepository<AppRecord> Apps { get; }
        DataRepository<AppEventRecord> Events { get; }
        DataRepository<ModifierCategoryRecord> ModifierCategories { get; }
        DataRepository<ModifierRecord> Modifiers { get; }
        DataRepository<AppRequestRecord> Requests { get; }
        DataRepository<ResourceGroupRoleRecord> ResourceGroupRoles { get; }
        DataRepository<ResourceGroupRecord> ResourceGroups { get; }
        DataRepository<ResourceRoleRecord> ResourceRoles { get; }
        DataRepository<ResourceRecord> Resources { get; }
        DataRepository<AppRoleRecord> Roles { get; }
        DataRepository<AppSessionRecord> Sessions { get; }
        DataRepository<AppUserRoleRecord> UserRoles { get; }
        DataRepository<AppUserRecord> Users { get; }
        DataRepository<AppVersionRecord> Versions { get; }
        Task Transaction(Func<Task> action);
    }
}