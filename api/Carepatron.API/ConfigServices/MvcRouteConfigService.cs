namespace Carepatron.ConfigServices;

public static class MvcRouteConfigService
{
    public static IApplicationBuilder RegisterMvcRouting(this IApplicationBuilder app)
    {
        app.UseRouting();

        app.UseEndpoints(endpoints => endpoints.MapControllers());

        return app;
    }
}