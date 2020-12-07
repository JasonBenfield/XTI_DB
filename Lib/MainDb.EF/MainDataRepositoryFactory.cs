using MainDB.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using XTI_Core;
using XTI_Core.EF;

namespace MainDB.EF
{
    public sealed class MainDataRepositoryFactory : DataRepositoryFactory
    {
        public MainDataRepositoryFactory(MainDbContext mainDbContext)
        {
            this.mainDbContext = mainDbContext;
            unitOfWork = new UnitOfWork(mainDbContext);
            dbSetLookup = new Dictionary<Type, object>
            {
                { typeof(AppEventRecord), mainDbContext.Events },
                { typeof(AppRecord), mainDbContext.Apps },
                { typeof(AppRequestRecord), mainDbContext.Requests },
                { typeof(AppRoleRecord), mainDbContext.Roles },
                { typeof(AppSessionRecord), mainDbContext.Sessions },
                { typeof(AppUserModifierRecord), mainDbContext.UserModifiers },
                { typeof(AppUserRecord), mainDbContext.Users },
                { typeof(AppUserRoleRecord), mainDbContext.UserRoles },
                { typeof(AppVersionRecord), mainDbContext.Versions },
                { typeof(ModifierCategoryAdminRecord), mainDbContext.ModifierCategoryAdmins },
                { typeof(ModifierCategoryRecord), mainDbContext.ModifierCategories },
                { typeof(ModifierRecord), mainDbContext.Modifiers },
                { typeof(ResourceGroupRecord), mainDbContext.ResourceGroups },
                { typeof(ResourceRecord), mainDbContext.Resources }
            };
        }

        private readonly MainDbContext mainDbContext;
        private readonly UnitOfWork unitOfWork;

        private readonly Dictionary<Type, object> dbSetLookup;

        public DataRepository<T> Create<T>() where T : class
            => new EfDataRepository<T>(unitOfWork, mainDbContext, (DbSet<T>)dbSetLookup[typeof(T)]);
    }
}
