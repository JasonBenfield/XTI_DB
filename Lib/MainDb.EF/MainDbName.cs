using XTI_DB;

namespace MainDB.EF
{
    public sealed class MainDbName : XtiDbName
    {
        public MainDbName(string environmentName) : base(environmentName, "Main")
        {
        }
    }
}
