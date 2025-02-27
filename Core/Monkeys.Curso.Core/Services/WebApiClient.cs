

namespace Monkeys.Curso.Core.Services;

public class WebApiClient : IWebApiClient
{
    public Task<(HttpStatusCode statusCode, TResponse result)> CallGetAsync<TResponse>(string url)
    {
        throw new NotImplementedException();
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
}
