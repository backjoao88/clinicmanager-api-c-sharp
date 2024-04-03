using System.Text;

namespace ClinicManager.Application.Appointments.Services.Contracts;

/// <summary>
/// Represents a link.
/// </summary>
public class Link
{
    public Link(string host, string resource, int port, Dictionary<string, string> queryParams)
    {
        Host = host;
        Resource = resource;
        Port = port;
        QueryParams = queryParams;
    }
    public string Host { get; set; }
    public string Resource { get; set; }
    public int Port { get; set; }
    public Dictionary<string, string> QueryParams { get; set; }

    /// <summary>
    /// Builds the current link.
    /// </summary>
    /// <returns></returns>
    public string BuildLink()
    {
        var queryParamsStringBuilder = new StringBuilder();
        foreach (var queryParam in QueryParams)
        {
            queryParamsStringBuilder.Append(queryParam.Key);
            queryParamsStringBuilder.Append("=");
            queryParamsStringBuilder.Append(queryParam.Value);
        }
        const string REQUEST_URL_FORMAT = "http://{0}:{1}/{2}?{3}";
        return String.Format(REQUEST_URL_FORMAT, Host, Port, Resource, queryParamsStringBuilder);
    }
}

public interface ILinkProvider
{
    /// <summary>
    /// Generates a new confirmation link based on a code.
    /// </summary>
    /// <param name="confirmationCode"></param>
    /// <returns></returns>
    public Link GenerateConfirmationLink(string confirmationCode);
    /// <summary>
    /// Generates a new cancelation link based on a code.
    /// </summary>
    /// <param name="confirmationCode"></param>
    /// <returns></returns>
    public Link GenerateCancelationLink(string confirmationCode);
}