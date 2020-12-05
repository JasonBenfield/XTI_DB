using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MainDB.EF
{
    public sealed class MainDbReset
    {
        private readonly MainDbContext appDbContext;

        public MainDbReset(MainDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task Run()
        {
            await appDbContext.Database.ExecuteSqlRawAsync
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
