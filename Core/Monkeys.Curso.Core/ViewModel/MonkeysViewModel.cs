using System.Text.Json;

namespace Monkeys.Curso.Core.ViewModel;

public partial class MonkeysViewModel : ObservableObject
{
    private readonly IMonkeysService MonkeysService;
    private readonly INavigationShellService NavigationShellService;
    private readonly IConnectivity ConnectivityService;

    public MonkeysViewModel(IMonkeysService monkeysService, INavigationShellService navigationShellService, IConnectivity connectivityService, IAppInfoService appInfoService)
    {
        MonkeysService = monkeysService;
        NavigationShellService = navigationShellService;
        ConnectivityService = connectivityService;

        var version = appInfoService.GetVersion();
        var platform = appInfoService.GetPlatform();
    }

    [ObservableProperty]
    private List<Monkey> monkeys = new();

    [ObservableProperty]
    private bool isRefreshing;

    [RelayCommand]
    public async Task GetMonkeys()
    {
        if (Connectivity.NetworkAccess == NetworkAccess.Internet)
        {
            var result = await MonkeysService.GetMonkeys();

            if (result != null)
                Monkeys = result;
            else
                Monkeys = new();
        }
        else
        {
            await NavigationShellService.ShowSnackbar("No hay conexión a internet");
        }
        IsRefreshing = false;
    }

    [RelayCommand]
    public async Task DetailMonkey(Monkey monkey)
    {
        if (monkey == null)
            return;

        await NavigationShellService.GoToNavigate("DetailsMonkeyPage", new Dictionary<string, object>
        {
            { "Monkey", monkey }
        });
    }

}
