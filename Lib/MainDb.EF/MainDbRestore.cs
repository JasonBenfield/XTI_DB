using System.Threading.Tasks;
using XTI_DB;

namespace MainDB.EF
{
    public sealed class MainDbRestore
    {
        private readonly MainDbContext mainDbContext;

        public MainDbRestore(MainDbContext mainDbContext)
        {
            this.mainDbContext = mainDbContext;
        }

        public Task Run(string environmentName, string backupFilePath)
            => new DbRestore(mainDbContext).Run(new MainDbName(environmentName), backupFilePath);
    }
}
