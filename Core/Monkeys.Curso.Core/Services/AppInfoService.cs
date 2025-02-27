namespace Monkeys.Curso.Core.Services;
// se realizo  la implementacion de la Intefarce  "IAppInfoService" en la cual se describen dos metodos  que nos proporcionan informacion sobre  la aplicacion 
class AppInfoService : IAppInfoService
{
    public string GetPlatform() =>
        DeviceInfo.Current.Platform.ToString();

    public string GetVersion() =>
        AppInfo.Version.ToString();
}
