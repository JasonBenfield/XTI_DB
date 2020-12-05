using System.Threading.Tasks;
using XTI_DB;

namespace MainDB.EF
{
    public sealed class MainDbBackup
    {
        private readonly MainDbContext mainDbContext;

        public MainDbBackup(MainDbContext mainDbContext)
        {
            this.mainDbContext = mainDbContext;
        }

        public Task Run(string environmentName, string backupFilePath)
            => new DbBackup(mainDbContext).Run(new MainDbName(environmentName), backupFilePath);
    }
}
