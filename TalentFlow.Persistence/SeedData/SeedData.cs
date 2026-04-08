using Microsoft.EntityFrameworkCore;
using TalentFlow.Domain.Entities;
using BCrypt.Net;

namespace TalentFlow.Persistence
{
    public static class SeedData
    {
        public static async Task InitializeAsync(TalentFlowDbContext context)
        {
            await context.Database.MigrateAsync();

            if (!context.Users.Any())
            {
                var admin = new User(
                    "admin@talentflow.com",
                    "System Admin",
                    BCrypt.Net.BCrypt.HashPassword("Admin123!"),
                    "Admin"
                );

                context.Users.Add(admin);
            }

            await context.SaveChangesAsync();
        }
    }
}
