namespace Carepatron.ConfigServices;

public static class SslRequiredConfigService
{
    public static IApplicationBuilder RegisterSslRequired(this IApplicationBuilder applicationBuilder)
    {
        applicationBuilder.UseHsts();
        applicationBuilder.UseHttpsRedirection();

        return applicationBuilder;
    }
}