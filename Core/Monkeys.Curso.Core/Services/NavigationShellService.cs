
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace Monkeys.Curso.Core.Services;

class NavigationShellService : INavigationShellService
{
    public async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }

    public async Task GoToNavigate(string url)
    {
        await Shell.Current.GoToAsync(url, true);
    }

    public async Task GoToNavigate(string url, Dictionary<string, object> parameters)
    {
        var navigationParams = new ShellNavigationQueryParameters();

        foreach (var param in navigationParams)
        {
            navigationParams.Add(param.Key, param.Value);
        }

        await Shell.Current.GoToAsync(url, true, navigationParams);
    }

    public async Task ShowSnackbar(string message)
    {

        try
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            var snackbarOptions = new SnackbarOptions()
            {
                BackgroundColor = Colors.Red,
                CornerRadius = 8,
                TextColor = Colors.White,
                Font = Microsoft.Maui.Font.SystemFontOfSize(14),
            };

            var snackbar = Snackbar.Make(message, actionButtonText:string.Empty,duration: TimeSpan.FromSeconds(5),visualOptions: snackbarOptions);
            await snackbar.Show(cts.Token);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al mostrar e modal \n"  + ex.Message);
        }


        

    }
}
