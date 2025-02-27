using Monkeys.Curso.Core.Services;
using Monkeys.Curso.Core.ViewModel;

namespace Monkeys.Curso.Helpers;

public static class IoC
{
    public static IServiceCollection AddDependencyContainer(this IServiceCollection services)
    {
        services.AddServices();
        services.AddViewModels();
        return services;
    }
}
