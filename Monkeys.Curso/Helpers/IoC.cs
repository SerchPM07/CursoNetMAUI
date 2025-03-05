using CommunityToolkit.Maui;
using Monkeys.Curso.Core.Services;
using Monkeys.Curso.Core.ViewModel;
using Monkeys.Curso.Pages;

namespace Monkeys.Curso.Helpers;

public static class IoC
{
    public static IServiceCollection AddDependencyContainer(this IServiceCollection services)
    {
        services.AddServices();
        services.AddViewModels();
        services.AddTransientWithShellRoute<DetailsMokeyPage, DetailsMokeyViewModel>("DetailsMokeyPage");
        services.AddSingleton<IMap>(Map.Default);
        services.AddSingleton<IGeolocation>(Geolocation.Default);
        services.AddSingleton<IConnectivity>(Connectivity.Current);
        return services;
    }
}
