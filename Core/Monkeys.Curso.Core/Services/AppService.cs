namespace Monkeys.Curso.Core.Services;

class AppService : IAppService
{
    public string NombreCompleto 
    { 
        get => Preferences.Get("NombreCompleto", "");
        set => Preferences.Set("NombreCompleto", value);
    }
    public string UrlServidor { get; } = "https://www.montemagno.com/monkeys.json"; //Esta ruta la debo de cambiar por la ruta de mi servidor
}
