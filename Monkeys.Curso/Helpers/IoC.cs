using CommunityToolkit.Maui;
using Monkeys.Curso.Core.Services;
using Monkeys.Curso.Core.ViewModel;
using Monkeys.Curso.Pages;

namespace Monkeys.Curso.Helpers;


// se creo una  clase estática que se llama  'IoC' para configurar el contenedor de dependencias.Sera parte esencial para crear  y configurara las dependencias que se iran utilizando
public static class IoC
{
    public static IServiceCollection AddDependencyContainer(this IServiceCollection services)
    {
        services.AddServices();
        services.AddViewModels();
        services.AddTransientWithShellRoute<DetailsMokeyPage, DetailsMokeyViewModel>("DetailsMokeyPage");
        return services;
    }
}
