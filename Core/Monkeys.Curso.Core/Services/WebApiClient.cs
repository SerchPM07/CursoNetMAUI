

using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Monkeys.Curso.Core.Services;

public class WebApiClient : IWebApiClient
{

    private readonly HttpClient _httpClient;
    private readonly IAppService _appService;
    private readonly JsonSerializerOptions _jsonSerializerOptions;


    public WebApiClient(IAppService appService)
    {
        _appService = appService;
        _jsonSerializerOptions = new()
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        };

        _httpClient = new HttpClient();
    }

    public async Task<(HttpStatusCode statusCode, TResponse result)> CallGetAsync<TResponse>(string url)
    {

        try
        {
            var response = await _httpClient.GetAsync($"{_appService.UrlServidor}{url}");
            return ProcessResponse<TResponse>(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al hacer la petición GET {0}\n" + ex.Message);
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


    private (HttpStatusCode statusCode, TResponse result) ProcessResponse<TResponse>(HttpResponseMessage response)
    {
        try
        {
            if(response.IsSuccessStatusCode)
            {
                var result = JsonSerializer.Deserialize<TResponse>(response.Content.ReadAsStringAsync().Result, _jsonSerializerOptions);
                return (response.StatusCode, result);
            }
            else
            {
                return (response.StatusCode, default);
            }
        }
        catch 
        {
            return(HttpStatusCode.InternalServerError, default);
        }
    }

}
