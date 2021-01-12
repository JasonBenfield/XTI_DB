﻿namespace MainDB.Entities
{
    public sealed class ResourceRoleRecord
    {
        public int ID { get; set; }
        public int ResourceID { get; set; }
        public int RoleID { get; set; }
        public bool IsAllowed { get; set; }
    }
}
