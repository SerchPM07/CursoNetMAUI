namespace Monkeys.Curso.Core.Services;

public static class DependencyContainer
{
    // se realiza una  registro de los servicios que contenera nuestra aplicacion 
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IAppInfoService, AppInfoService>();
        services.AddSingleton<IAppService, AppService>();
        services.AddSingleton<INavigationShellService, NavigationShellService>();
        services.AddSingleton<IWebApiClient, WebApiClient>();
        services.AddSingleton<IMonkeysService, MonkeysService>();
        return services;
    }
}