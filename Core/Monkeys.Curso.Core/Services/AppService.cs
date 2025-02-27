namespace Monkeys.Curso.Core.Services;
// se implementa la interfas "IAppService" en la cual se tiene  una propiedad que tiene el nombre de  'NombreComplet' que se usa para obtener informacion al igual que determinar un valor,
//al igual  que otra propiedad que nos hara una consulta a una URL.

class AppService : IAppService
{
    public string NombreCompleto 
    { 
        get => Preferences.Get("NombreCompleto", ""); 
        set => Preferences.Set("NombreCompleto", value); 
    }

    public string UrlServidor { get; } = "https://www.montemagno.com/monkeys.json";
}
