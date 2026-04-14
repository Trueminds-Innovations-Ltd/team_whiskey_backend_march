// File Path: TalentFlow.Persistence/DesignTimeDbContextFactory.cs

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace TalentFlow.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TalentFlowDbContext>
    {
        public TalentFlowDbContext CreateDbContext(string[] args)
        {
            // Detect environment (defaults to Development if not set)
            var environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Development";

            // Load configuration from appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .Build();

            // ✅ Correctly pick the connection string based on environment
            var connectionString = configuration.GetSection("ConnectionStrings")[environment];

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException(
                    $"Connection string for environment '{environment}' was not found. " +
                    $"Make sure appsettings.json has ConnectionStrings:{environment} defined."
                );
            }

            var optionsBuilder = new DbContextOptionsBuilder<TalentFlowDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new TalentFlowDbContext(optionsBuilder.Options);
        }
    }
}
