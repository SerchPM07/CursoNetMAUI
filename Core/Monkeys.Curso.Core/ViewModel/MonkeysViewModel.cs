using System.Threading.Tasks;

namespace Monkeys.Curso.Core.ViewModel;

public partial class MonkeysViewModel : ObservableObject
{
    private readonly IMonkeysService MonkeysService;
    private readonly INavigationShellService NavigationShellService;
    public MonkeysViewModel(IMonkeysService monkeysService, INavigationShellService navigationShellService)
    {
        MonkeysService = monkeysService;
        NavigationShellService = navigationShellService;
    }

    [ObservableProperty]
    private List<Monkey> monkeys = new();

    [ObservableProperty]
    private bool isRefreshing;

    [RelayCommand]
    public async Task GetMonkeys()
    {
        var result = await MonkeysService.GetMonkeys();

        if (result != null)
            Monkeys = result;
        else
            Monkeys = new();
        IsRefreshing = false;
    }

    [RelayCommand]
    public async Task DetailMonkey(Monkey monkey)
    {
        if (monkey == null)
            return;

        await NavigationShellService.GoToNavigate("DetailsMokeyPage", new Dictionary<string, object>
        {
            { "Monkey", monkey}
        });
    }
}
