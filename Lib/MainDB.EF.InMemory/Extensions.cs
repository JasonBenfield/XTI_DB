using MainDB.EF;
using MainDB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MainDB.Extensions
{
    public static class Extensions
    {
        public static void AddMainDbContextForInMemory(this IServiceCollection services)
        {
            services.AddDbContext<MainDbContext>(options =>
            {
                options
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .EnableSensitiveDataLogging();
            });
            services.AddScoped<IMainDbContext, MainDbContext>();
        }
    }
}
