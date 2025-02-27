namespace Monkeys.Curso.Core.Services;

public static class DependencyContainer
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IAppInfoService, AppInfoService>();
        services.AddSingleton<IAppService, AppService>();
        services.AddSingleton<INavigationShellService, NavigationShellService>();
        services.AddSingleton<IWebApiClient, WebApiClient>();
        return services;
    }
}
