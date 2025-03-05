using CommunityToolkit.Mvvm.ComponentModel;
using System.Threading.Tasks;

namespace Monkeys.Curso.Core.ViewModel;

public partial class DetailsMokeyViewModel : ObservableObject, IQueryAttributable
{
    private readonly INavigationShellService NavigationShellService;
    private readonly IMap Map;
    private readonly IGeolocation Geolocation;

    public DetailsMokeyViewModel(INavigationShellService navigationShellService, IMap map, IGeolocation geolocation)
    {
        NavigationShellService = navigationShellService;
        Map = map;
        Geolocation = geolocation;
    }

    [ObservableProperty]
    private Monkey monkey;

    [RelayCommand]
    public async Task GoBack() =>
        await NavigationShellService.GoBack();

    [RelayCommand]
    public async Task OpenMapMonkey()
    {
        await Map.OpenAsync(Monkey.Latitude, Monkey.Longitude, new MapLaunchOptions
        {
            Name = Monkey.Name,
            NavigationMode = NavigationMode.None
        });
    }

    [RelayCommand]
    public async Task GetDistancia()
    {
        var location = await Geolocation.GetLastKnownLocationAsync();
        if(location == null)
        {
            location = await Geolocation.GetLocationAsync(new GeolocationRequest
            {
                DesiredAccuracy = GeolocationAccuracy.Medium,
                Timeout = TimeSpan.FromSeconds(30)
            });
        }

        var distancia = location.CalculateDistance(new Location(Monkey.Latitude, Monkey.Longitude), DistanceUnits.Kilometers);

        await NavigationShellService.ShowSnackbar($"La distancia es: {distancia} K");
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query != null && query.Count > 0)
            Monkey = query["MonkeyKey"] as Monkey;
    }
}
