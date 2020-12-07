﻿using XTI_Core;

namespace MainDB.Entities
{
    public interface IMainDataRepositoryFactory
    {
        DataRepository<AppUserRecord> CreateUsers();
        DataRepository<AppSessionRecord> CreateSessions();
        DataRepository<AppRequestRecord> CreateRequests();
        DataRepository<AppEventRecord> CreateEvents();
        DataRepository<AppRecord> CreateApps();
        DataRepository<AppVersionRecord> CreateVersions();
        DataRepository<AppRoleRecord> CreateRoles();
        DataRepository<AppUserRoleRecord> CreateUserRoles();
        DataRepository<ResourceGroupRecord> CreateResourceGroups();
        DataRepository<ResourceRecord> CreateResources();
        DataRepository<ModifierCategoryRecord> CreateModifierCategories();
        DataRepository<ModifierCategoryAdminRecord> CreateModifierCategoryAdmins();
        DataRepository<ModifierRecord> CreateModifiers();
        DataRepository<AppUserModifierRecord> CreateUserModifiers();
    }
}