
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace Monkeys.Curso.Core.Services;

//su funcion inicial es la navegacion de la aplicacion, utiliza el metodo Snackbar para generar notificaciones 
class NavigationShellService : INavigationShellService
{
    public async Task GoBack() =>
        await Shell.Current.GoToAsync("..");

    public async Task GoToNavigate(string url) =>
        await Shell.Current.GoToAsync(url, true);

    public async Task GoToNavigate(string url, Dictionary<string, object> parameters)
    {
        var navigationParameters = new ShellNavigationQueryParameters();
        foreach (var parm in parameters)
            navigationParameters.Add(parm.Key, parm.Value);
        await Shell.Current.GoToAsync(url, true, navigationParameters);
    }

    public async Task ShowSnackbar(string message)
    {
        try
        {
            CancellationTokenSource cancellationTokenSource = new();
            var snackbarOptions = new SnackbarOptions
            {
                BackgroundColor = Colors.Red,
                TextColor = Colors.White,
                CornerRadius = new CornerRadius(10),
                Font = Microsoft.Maui.Font.SystemFontOfSize(16)
            };

            var snackbar = Snackbar.Make(message, actionButtonText: string.Empty, duration: TimeSpan.FromSeconds(5), visualOptions: snackbarOptions);
            await snackbar.Show(cancellationTokenSource.Token);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error al mostrar el modal: {0}", e.Message);
        }
       
    }
}
