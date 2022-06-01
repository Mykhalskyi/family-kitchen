using FluentMigrator.Runner;

namespace FamilyKitchen.WebAPI.Migrations
{
    internal static class MigrationsExtensions
    {
        internal static IApplicationBuilder Migrate(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
            runner.ListMigrations();
            runner.MigrateUp();
            return app;
        }
    }
}
