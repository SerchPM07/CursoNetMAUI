namespace Monkeys.Curso.Core.Services;

class AppInfoService : IAppInfoService
{
    public string GetPlatform() =>
        DeviceInfo.Current.Platform.ToString();


    public string GetVersion() =>
        AppInfo.Version.ToString();
}
