﻿using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MainDB.EF
{
    public sealed class MainDbReset
    {
        private readonly MainDbContext mainDbContext;

        public MainDbReset(MainDbContext mainDbContext)
        {
            this.mainDbContext = mainDbContext;
        }

        public async Task Run()
        {
            await mainDbContext.Database.ExecuteSqlRawAsync
            (
                @"
exec sp_MSForEachTable 'IF OBJECT_ID(''?'') <> ISNULL(OBJECT_ID(''[dbo].[__EFMigrationsHistory]''),0) ALTER TABLE ? NOCHECK CONSTRAINT all';

exec sp_MSForEachTable '
    set rowcount 0; 
    SET QUOTED_IDENTIFIER ON; 
    IF OBJECT_ID(''?'') <> ISNULL(OBJECT_ID(''[dbo].[__EFMigrationsHistory]''),0) 
        DELETE FROM ?;';

exec sp_MSForEachTable 'IF OBJECT_ID(''?'') <> ISNULL(OBJECT_ID(''[dbo].[__EFMigrationsHistory]''),0) ALTER TABLE ? WITH CHECK CHECK CONSTRAINT all';

exec sp_MSForEachTable 'IF OBJECT_ID(''?'') <> ISNULL(OBJECT_ID(''[dbo].[__EFMigrationsHistory]''),0) DBCC CHECKIDENT(''?'', RESEED, 0)';
"
            );
        }
    }
}
