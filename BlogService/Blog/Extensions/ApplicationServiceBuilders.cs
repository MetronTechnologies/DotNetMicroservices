using Blog.Infrastructure.Data;
using Blog.Infrastructure.Seeders;
using Blog.MiddleWares;
using Microsoft.EntityFrameworkCore;
using NLog.Web;

namespace Blog.Extensions; 

public static class ApplicationServiceBuilders {
    public static async void AddApplicationServiceBuilder(this IApplicationBuilder builder, IServiceScope scope) {
        builder.UseMiddleware<ErrorHandlingMiddleware>();
        builder.UseHttpsRedirection();
        builder.UseAuthorization();
        await using var db = scope.ServiceProvider.GetRequiredService<BlogDbContext>();
        var pendingMigration = await db?.Database.GetPendingMigrationsAsync()!;
        if (pendingMigration.Any()) {
            await db?.Database.MigrateAsync()!;
            var totalAppliedMigration = db?.Database.GetAppliedMigrations().Count();
        }
        var totalAppliedMigrations = await db.Database.GetAppliedMigrationsAsync();
        var count = totalAppliedMigrations.ToList().Count;
        
        var seeder = scope.ServiceProvider.GetRequiredService<IBlogServiceSeeder>();
        await seeder.Seed();
    }
}