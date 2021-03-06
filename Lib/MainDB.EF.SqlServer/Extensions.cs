﻿using MainDB.EF;
using MainDB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using XTI_Core.Extensions;
using XTI_DB;

namespace MainDB.Extensions
{
    public static class Extensions
    {
        public static void AddMainDbContextForSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DbOptions>(configuration.GetSection(DbOptions.DB));
            services.AddDbContext<MainDbContext>((sp, options) =>
            {
                var appDbOptions = sp.GetService<IOptions<DbOptions>>().Value;
                var hostEnvironment = sp.GetService<IHostEnvironment>();
                var connectionString = new MainConnectionString(appDbOptions, hostEnvironment.EnvironmentName).Value();
                options
                    .UseSqlServer(connectionString, b => b.MigrationsAssembly("MainDB.EF.SqlServer"));
                if (hostEnvironment?.IsDevOrTest() == true)
                {
                    options.EnableSensitiveDataLogging();
                }
                else
                {
                    options.EnableSensitiveDataLogging(false);
                }
            });
            services.AddScoped<IMainDbContext>(sp => sp.GetService<MainDbContext>());
        }
    }
}
