using Carepatron.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace Carepatron.ConfigServices;

public static class DbContextConfigService
{
    public static IServiceCollection RegisterDatabaseContext(this IServiceCollection services)
    {
        services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("Test"));

        return services;
    }
}