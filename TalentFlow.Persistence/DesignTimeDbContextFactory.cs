using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

using System.IO;

using System;
using System.IO;

namespace TalentFlow.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TalentFlowDbContext>
    {
        public TalentFlowDbContext CreateDbContext(string[] args)
        {
            // Load configuration from appsettings files
            var environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Development";

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<TalentFlowDbContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (environment == "Development")
            {
                // ✅ Local SQL Server for dev
                optionsBuilder.UseSqlServer(connectionString);
            }
            else
            {
                // ✅ Postgres for production
                optionsBuilder.UseNpgsql(connectionString);
            }

            return new TalentFlowDbContext(optionsBuilder.Options);
        }
    }
}
