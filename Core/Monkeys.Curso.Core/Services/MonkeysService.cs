namespace Monkeys.Curso.Core.Services;

class MonkeysService : IMonkeysService
{
    private readonly IWebApiClient WebApiClient;
    public MonkeysService(IWebApiClient webApiClient)
    {
        WebApiClient = webApiClient;
    }

    public async Task<List<Monkey>> GetMonkeys()
    {
        (HttpStatusCode httpStatsuCode, List<Monkey> result) = await WebApiClient.CallGetAsync<List<Monkey>>();

        if (httpStatsuCode == HttpStatusCode.OK)
            return result;
        return null;
    }
}
