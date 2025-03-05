using System.Threading.Tasks;

namespace Monkeys.Curso.Core.ViewModel;

public partial class MonkeysViewModel : ObservableObject
{
    private readonly IMonkeysService MonkeysService;
    private readonly INavigationShellService NavigationShellService;
    private readonly IConnectivity Connectivity;
    public MonkeysViewModel(IMonkeysService monkeysService, INavigationShellService navigationShellService, IConnectivity connectivity, IAppInfoService appInfoService)
    {
        MonkeysService = monkeysService;
        NavigationShellService = navigationShellService;
        Connectivity = connectivity;

        var version = appInfoService.GetVersion();
        var plataforma = appInfoService.GetPlatform();
    }

    [ObservableProperty]
    private List<Monkey> monkeys = new();

    [ObservableProperty]
    private bool isRefreshing;

    [RelayCommand]
    public async Task GetMonkeys()
    {
        if( Connectivity.NetworkAccess == NetworkAccess.Internet)
        {
            var result = await MonkeysService.GetMonkeys();

            if (result != null)
                Monkeys = result;
            else
                Monkeys = new();
        }
        else
        {
            await NavigationShellService.ShowSnackbar("Sin acceso a internet");
        }
        IsRefreshing = false;
    }

    [RelayCommand]
    public async Task DetailMonkey(Monkey monkey)
    {
        if (monkey == null)
            return;

        await NavigationShellService.GoToNavigate("DetailsMokeyPage", new Dictionary<string, object>
        {
            { "MonkeyKey", monkey}
        });
    }
}
