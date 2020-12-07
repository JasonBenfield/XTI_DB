using MainDB.Entities;
using XTI_Core;
using XTI_Core.EF;

namespace MainDB.EF
{
    public sealed class MainDataRepositoryFactory : IMainDataRepositoryFactory
    {
        private readonly MainDbContext mainDbContext;
        private readonly UnitOfWork unitOfWork;

        public MainDataRepositoryFactory(MainDbContext mainDbContext)
        {
            this.mainDbContext = mainDbContext;
            unitOfWork = new UnitOfWork(mainDbContext);
        }

        public DataRepository<AppUserRecord> CreateUsers()
            => new EfDataRepository<AppUserRecord>(unitOfWork, mainDbContext, mainDbContext.Users);

        public DataRepository<AppSessionRecord> CreateSessions()
            => new EfDataRepository<AppSessionRecord>(unitOfWork, mainDbContext, mainDbContext.Sessions);

        public DataRepository<AppRequestRecord> CreateRequests()
            => new EfDataRepository<AppRequestRecord>(unitOfWork, mainDbContext, mainDbContext.Requests);

        public DataRepository<AppEventRecord> CreateEvents()
            => new EfDataRepository<AppEventRecord>(unitOfWork, mainDbContext, mainDbContext.Events);

        public DataRepository<AppRecord> CreateApps()
            => new EfDataRepository<AppRecord>(unitOfWork, mainDbContext, mainDbContext.Apps);

        public DataRepository<AppVersionRecord> CreateVersions()
            => new EfDataRepository<AppVersionRecord>(unitOfWork, mainDbContext, mainDbContext.Versions);

        public DataRepository<AppRoleRecord> CreateRoles()
            => new EfDataRepository<AppRoleRecord>(unitOfWork, mainDbContext, mainDbContext.Roles);

        public DataRepository<AppUserRoleRecord> CreateUserRoles()
            => new EfDataRepository<AppUserRoleRecord>(unitOfWork, mainDbContext, mainDbContext.UserRoles);

        public DataRepository<ResourceGroupRecord> CreateResourceGroups()
            => new EfDataRepository<ResourceGroupRecord>(unitOfWork, mainDbContext, mainDbContext.ResourceGroups);

        public DataRepository<ResourceRecord> CreateResources()
            => new EfDataRepository<ResourceRecord>(unitOfWork, mainDbContext, mainDbContext.Resources);

        public DataRepository<ModifierCategoryRecord> CreateModifierCategories()
            => new EfDataRepository<ModifierCategoryRecord>(unitOfWork, mainDbContext, mainDbContext.ModifierCategories);

        public DataRepository<ModifierCategoryAdminRecord> CreateModifierCategoryAdmins()
            => new EfDataRepository<ModifierCategoryAdminRecord>(unitOfWork, mainDbContext, mainDbContext.ModifierCategoryAdmins);

        public DataRepository<ModifierRecord> CreateModifiers()
            => new EfDataRepository<ModifierRecord>(unitOfWork, mainDbContext, mainDbContext.Modifiers);

        public DataRepository<AppUserModifierRecord> CreateUserModifiers()
            => new EfDataRepository<AppUserModifierRecord>(unitOfWork, mainDbContext, mainDbContext.UserModifiers);
    }
}
