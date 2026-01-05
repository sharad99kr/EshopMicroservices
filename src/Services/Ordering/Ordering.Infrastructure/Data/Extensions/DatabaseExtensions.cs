

using Microsoft.AspNetCore.Builder;

namespace Ordering.Infrastructure.Data.Extensions
{
    public static class DatabaseExtensions
    {
        public static async Task InitialiseDatabaseAsync(this WebApplication app) {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.MigrateAsync().GetAwaiter().GetResult();

            //seed data
            await SeedAsync(context);
        }

        public static async Task SeedAsync(ApplicationDbContext context) { 
            await SeedCustomerAsync(context);
        }
        public static async Task SeedCustomerAsync(ApplicationDbContext context) {
            if(!await context.Customers.AnyAsync()) {
                await context.Customers.AddRangeAsync(InitialData.Customers);
                await context.SaveChangesAsync();
            }
        }     
    }
}
