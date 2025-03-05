namespace Monkeys.Curso.Core.ViewModel;

public static class DependencyContainer
{
    public static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        services.AddTransient<MonkeysViewModel>();
        //services.AddTransient<DetailsMokeyViewModel>();
        return services;
    }
}
