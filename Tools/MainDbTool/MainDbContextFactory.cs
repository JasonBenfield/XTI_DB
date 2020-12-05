using MainDB.EF;
using MainDB.Extensions;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using XTI_Configuration.Extensions;

namespace MainDbTool
{
    public sealed class MainDbContextFactory : IDesignTimeDbContextFactory<MainDbContext>
    {
        public MainDbContext CreateDbContext(string[] args)
        {
            var host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.UseXtiConfiguration(hostingContext.HostingEnvironment, args);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.Configure<MainDbToolOptions>(hostContext.Configuration);
                    services.AddAppDbContextForSqlServer(hostContext.Configuration);
                })
                .Build();
            var scope = host.Services.CreateScope();
            return scope.ServiceProvider.GetService<MainDbContext>();
        }
    }
}
