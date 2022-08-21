using Carepatron.DAL.Data;

namespace Carepatron.ConfigServices;

public static class DbSeedConfigService
{
    public static IApplicationBuilder SeedDatabase(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var dataSeeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();

        dataSeeder.Seed();

        return app;
    }
}