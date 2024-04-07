using System.Net.Http.Headers;
using Google.Apis.Http;

namespace ClinicManager.Infrastructure.Services.GoogleCalendar;

/// <summary>
/// Represents a custom user credentials to intercepts http requests with an access token.
/// </summary>
public class GoogleCalendarCredentialsInterceptor : IHttpExecuteInterceptor, IConfigurableHttpClientInitializer
{
    private string _accessToken;

    public GoogleCalendarCredentialsInterceptor(string accessToken)
    {
        _accessToken = accessToken;
    }

    /// <summary>
    /// Sets the access token to the client.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task InterceptAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
        return Task.CompletedTask;
    }

    public void Initialize(ConfigurableHttpClient httpClient)
    {
        httpClient.MessageHandler.AddExecuteInterceptor(this);
    }
}