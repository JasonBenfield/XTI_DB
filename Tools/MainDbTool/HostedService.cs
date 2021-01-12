﻿using MainDB.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;
using XTI_Core.Extensions;

namespace MainDbTool
{
    public sealed class HostedService : IHostedService
    {
        private readonly IServiceProvider sp;

        public HostedService(IServiceProvider sp)
        {
            this.sp = sp;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = sp.CreateScope();
            var options = scope.ServiceProvider.GetService<IOptions<MainDbToolOptions>>().Value;
            var hostEnvironment = scope.ServiceProvider.GetService<IHostEnvironment>();
            try
            {
                if (options.Command == "reset")
                {
                    if (!hostEnvironment.IsTest() && !options.Force)
                    {
                        throw new ArgumentException("Database reset can only be run for the test environment");
                    }
                    var mainDbReset = scope.ServiceProvider.GetService<MainDbReset>();
                    await mainDbReset.Run();
                }
                else if (options.Command == "backup")
                {
                    if (string.IsNullOrWhiteSpace(options.BackupFilePath))
                    {
                        throw new ArgumentException("Backup file path is required for backup");
                    }
                    var mainDbBackup = scope.ServiceProvider.GetService<MainDbBackup>();
                    await mainDbBackup.Run(hostEnvironment.EnvironmentName, options.BackupFilePath);
                }
                else if (options.Command == "restore")
                {
                    if (hostEnvironment.IsProduction())
                    {
                        throw new ArgumentException("Database restore cannot be run for the production environment");
                    }
                    if (string.IsNullOrWhiteSpace(options.BackupFilePath))
                    {
                        throw new ArgumentException("Backup file path is required for restore");
                    }
                    var mainDbRestore = scope.ServiceProvider.GetService<MainDbRestore>();
                    await mainDbRestore.Run(hostEnvironment.EnvironmentName, options.BackupFilePath);
                }
                else if (options.Command == "update")
                {
                    var mainDbContext = scope.ServiceProvider.GetService<MainDbContext>();
                    await mainDbContext.Database.MigrateAsync();
                }
                else
                {
                    throw new NotSupportedException($"Command '{options.Command}' is not supported");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Environment.ExitCode = 999;
            }
            var lifetime = scope.ServiceProvider.GetService<IHostApplicationLifetime>();
            lifetime.StopApplication();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
