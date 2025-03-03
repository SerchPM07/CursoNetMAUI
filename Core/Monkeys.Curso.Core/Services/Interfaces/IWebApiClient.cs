namespace Monkeys.Curso.Core.Services.Interfaces;

public interface IWebApiClient
{
    Task<(HttpStatusCode statusCode, TResponse result)> CallGetAsync<TResponse>(string url = "");
    Task<(HttpStatusCode statusCode, TResponse result)> CallGetAsync<TResponse>(string url, params(string, object)[] parameters);
    Task<(HttpStatusCode statusCode, TResponse result)> CallPostAsync<TResponse, TRequest>(string url, TRequest request);
    Task<(HttpStatusCode statusCode, TResponse result)> CallPutAsync<TResponse, TRequest>(string url, TRequest request);
}
