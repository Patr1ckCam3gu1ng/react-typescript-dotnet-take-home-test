namespace Carepatron.ConfigServices;

public static class CorsConfigService
{
    public static IServiceCollection RegisterCors(this IServiceCollection services)
    {
        // cors
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder => builder
                .SetIsOriginAllowedToAllowWildcardSubdomains()
                .WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
                .Build());
        });

        return services;
    }
}