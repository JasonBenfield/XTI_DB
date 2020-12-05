using Microsoft.Extensions.Options;
using XTI_DB;

namespace MainDB.EF
{
    public sealed class MainConnectionString : XtiConnectionString
    {
        public MainConnectionString(IOptions<DbOptions> options, string envName)
            : this(options.Value, envName)
        {
        }

        public MainConnectionString(DbOptions options, string envName)
            : base(options, new MainDbName(envName))
        {
        }
    }
}
