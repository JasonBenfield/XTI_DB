using MainDB.EF;
using MainDB.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using XTI_Configuration.Extensions;
using XTI_DB;

namespace MainDbTool
{
    class Program
    {
        static Task Main(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.UseXtiConfiguration(hostingContext.HostingEnvironment, args);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.Configure<MainDbToolOptions>(hostContext.Configuration);
                    services.Configure<DbOptions>(hostContext.Configuration.GetSection(DbOptions.DB));
                    services.AddMainDbContextForSqlServer(hostContext.Configuration);
                    services.AddScoped<MainDbReset>();
                    services.AddScoped<MainDbBackup>();
                    services.AddScoped<MainDbRestore>();
                    services.AddHostedService<HostedService>();
                })
                .RunConsoleAsync();
        }
    }
}
