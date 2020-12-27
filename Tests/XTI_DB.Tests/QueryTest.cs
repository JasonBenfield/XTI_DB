using MainDB.EF;
using MainDB.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;
using XTI_Configuration.Extensions;
using XTI_Core;

namespace XTI_DB.Tests
{
    public sealed class QueryTests
    {
        [Test]
        public async Task ShouldQueryByTimeRange()
        {
            var input = setup();
            var timeRange = TimeRange.Between(DateTime.Now.Date, DateTime.Now.AddHours(1));
            var requests = await input.MainDbContext.Requests
                .Where(r => r.TimeStarted >= timeRange.Start && r.TimeStarted <= timeRange.End)
                .ToArrayAsync();
            Console.WriteLine(requests.Length);
        }

        private TestInput setup()
        {
            Environment.SetEnvironmentVariable("DOTNET_ENVIRONMENT", "Development");
            var host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration
                (
                    (hostContext, config) =>
                    {
                        config.UseXtiConfiguration(hostContext.HostingEnvironment, new string[] { });
                    }
                )
                .ConfigureServices
                (
                    (hostContext, services) =>
                    {
                        services.AddAppDbContextForSqlServer(hostContext.Configuration);
                    }
                )
                .Build();
            var scope = host.Services.CreateScope();
            return new TestInput(scope.ServiceProvider);
        }

        private sealed class TestInput
        {
            public TestInput(IServiceProvider sp)
            {
                MainDbContext = sp.GetService<MainDbContext>();
            }
            public MainDbContext MainDbContext { get; }
        }
    }
}