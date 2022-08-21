using Carepatron.BLL.Services;
using Carepatron.BLL.Services.Interfaces;
using Carepatron.DAL.Data;
using Carepatron.DAL.Repositories;
using Carepatron.DAL.Repositories.Interfaces;

namespace Carepatron.ConfigServices;

public static class DInjectionConfigService
{
    public static IServiceCollection RegisterDInjection(this IServiceCollection services)
    {
        services.AddScoped<DataSeeder>();
        
        #region Services

        services.AddScoped<IClientService, ClientService>();

        #endregion

        #region Repositories

        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<ICacheRepository, CacheRepository>();

        #endregion

        return services;
    }
}