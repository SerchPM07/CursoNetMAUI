using System.Text.Json;

namespace Monkeys.Curso.Core.Services;

public class WebApiClient : IWebApiClient
{

    // se a creado  una clase la cual es 'WebApiclient ' que implementa el cliente HTTP para realizar llamadas GET, y tienes la estructura básica para implementar POST y PUT.
    private readonly HttpClient HttpClient;
    private readonly IAppService AppService;
    private readonly JsonSerializerOptions JsonSerializerOptions;

    public WebApiClient(IAppService appService)
    {
        AppService = appService;
        JsonSerializerOptions = new()
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        };

        HttpClient = new HttpClient();
    }

    public async Task<(HttpStatusCode statusCode, TResponse result)> CallGetAsync<TResponse>(string url = "")
    {
        try
        {
            var response = await HttpClient.GetAsync($"{AppService.UrlServidor}{url}");
            return ProcessResponse<TResponse>(response);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error en el servidor: {0}", e.Message);
            return (HttpStatusCode.BadRequest, default);
        }
    }

    public Task<(HttpStatusCode statusCode, TResponse result)> CallGetAsync<TResponse>(string url, params (string, object)[] parameters)
    {
        throw new NotImplementedException();
    }

    public Task<(HttpStatusCode statusCode, TResponse result)> CallPostAsync<TResponse, TRequest>(string url, TRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<(HttpStatusCode statusCode, TResponse result)> CallPutAsync<TResponse, TRequest>(string url, TRequest request)
    {
        throw new NotImplementedException();
    }

    private (HttpStatusCode statusCode, TResponse response) ProcessResponse<TResponse>(HttpResponseMessage httpResponse)
    {
        try
        {
            if (httpResponse.IsSuccessStatusCode)
            {
                var response = JsonSerializer.Deserialize<TResponse>(httpResponse.Content.ReadAsStringAsync().Result, JsonSerializerOptions);

                return (httpResponse.StatusCode, response);
            }
            return (httpResponse.StatusCode, default);

        }
        catch
        {
            return (HttpStatusCode.InternalServerError, default);
        }
    }
}
