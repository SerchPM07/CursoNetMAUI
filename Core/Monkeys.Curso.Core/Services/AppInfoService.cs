namespace Monkeys.Curso.Core.Services;

class AppInfoService : IAppInfoService
{
    public string GetPlatform()
    {
        return DeviceInfo.Current.Platform.ToString();
    }

    public string GetVersion()
    {
        return AppInfo.VersionString;
    }
}
