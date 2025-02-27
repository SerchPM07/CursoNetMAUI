namespace Monkeys.Curso.Core.Services.Interfaces;

public interface INavigationShellService
{
    Task ShowSnackbar(string message);
    Task GoToNavigate(string url);
    Task GoToNavigate(string url, Dictionary<string, object> parameters);
    Task GoBack();
}
