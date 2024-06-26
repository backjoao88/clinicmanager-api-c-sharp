﻿using System.Text;
using ClinicManager.Application.Shared.Services.GoogleCalendar;
using ClinicManager.Application.Shared.Services.GoogleCalendar.Dtos;
using ClinicManager.Infrastructure.Services.GoogleCalendar.Options;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Requests;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Microsoft.Extensions.Options;

namespace ClinicManager.Infrastructure.Services.GoogleCalendar;

public class GoogleCalendarService : IGoogleCalendarService
{
    private readonly GoogleCalendarCredentialsOptions _googleCalendarCredentialsOptions;

    public GoogleCalendarService(IOptions<GoogleCalendarCredentialsOptions> googleCalendarApplicationCredentialsOptions)
    {
        _googleCalendarCredentialsOptions = googleCalendarApplicationCredentialsOptions.Value;
    }

    public Google.Apis.Calendar.v3.CalendarService BuildClient(string accessToken)
    {
        return new Google.Apis.Calendar.v3.CalendarService(new BaseClientService.Initializer()
        { 
            HttpClientInitializer = new GoogleCalendarCredentialsInterceptor(accessToken),
            ApplicationName = _googleCalendarCredentialsOptions.ApplicationName
        });
    }

    /// <inheritdoc/>>
    public async Task<GoogleCalendarCredentialsResponse> HandleAuthorizationCode(string authorizationCode)
    {
        const string GRANT_TYPE = "authorization_code";
        var authorizationCodeTokenRequest = new AuthorizationCodeTokenRequest()
        {
            Code = authorizationCode,
            ClientId = _googleCalendarCredentialsOptions.ClientId,
            ClientSecret = _googleCalendarCredentialsOptions.ClientSecret,
            RedirectUri = _googleCalendarCredentialsOptions.RedirectUri,
            GrantType = GRANT_TYPE
        };
        var authorizationCodeFlow = new AuthorizationCodeFlow(new AuthorizationCodeFlow.Initializer(
            _googleCalendarCredentialsOptions.AuthUri,
            _googleCalendarCredentialsOptions.TokenUri
        )
        {
            ClientSecrets = new ClientSecrets()
            {
                ClientId = _googleCalendarCredentialsOptions.ClientId,
                ClientSecret = _googleCalendarCredentialsOptions.ClientSecret,
            },
        });
        var result = await authorizationCodeFlow.FetchTokenAsync(
            "mail@gmail.com", 
            authorizationCodeTokenRequest, 
            CancellationToken.None
        );
        var client = BuildClient(result.AccessToken);
        var calendarRequest = client.Calendars.Get("primary");
        var calendar = await calendarRequest.ExecuteAsync();
        var issuerName = calendar.Id;
        return new GoogleCalendarCredentialsResponse(
            issuerName, 
            result.AccessToken, 
            result.RefreshToken, 
            DateTime.Now.AddSeconds((double)result.ExpiresInSeconds!
            )
        );
    }

    /// <inheritdoc/>>
    public string BuildAuthorizationLink()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append(_googleCalendarCredentialsOptions.AuthUri);
        stringBuilder.Append("?client_id=");
        stringBuilder.Append(_googleCalendarCredentialsOptions.ClientId);
        stringBuilder.Append("&access_type=offline&include_granted_scopes=true&response_type=code&redirect_uri=");
        stringBuilder.Append(_googleCalendarCredentialsOptions.RedirectUri);
        stringBuilder.Append("&scope=https://www.googleapis.com/auth/calendar");
        return stringBuilder.ToString();
    }

    /// <inheritdoc/>>
    public async Task<GoogleCalendarEventResponse> CreateEvent(GoogleCalendarEventRequest googleCalendarEventRequest)
    {
        var client = BuildClient(googleCalendarEventRequest.AccessToken);
        var eventAttendees = googleCalendarEventRequest
            .Attendees
            .Select(o =>
            {
                return new EventAttendee()
                {
                    Email = o
                };
            })
            .ToList();
        var @event = new Event()
        {
            Summary = googleCalendarEventRequest.Summary,
            Description = googleCalendarEventRequest.Description,
            Start = new EventDateTime()
            {
                DateTimeDateTimeOffset = new DateTimeOffset(googleCalendarEventRequest.Start)
            },
            Attendees = eventAttendees,
            End = new EventDateTime()
            {
                DateTimeDateTimeOffset = new DateTimeOffset(googleCalendarEventRequest.End)
            }
        };
        var response = await client.Events.Insert(@event, googleCalendarEventRequest.CalendarId).ExecuteAsync();
        return new GoogleCalendarEventResponse(response.Summary, response.Description);
    }

    /// <inheritdoc/>>
    public async Task<GoogleCalendarCredentialsResponse> RefreshToken(string refreshToken)
    {
        const string GRANT_TYPE = "refresh_token";
        var authorizationCodeTokenRequest = new RefreshTokenRequest()
        {
            RefreshToken = refreshToken,
            ClientId = _googleCalendarCredentialsOptions.ClientId,
            ClientSecret = _googleCalendarCredentialsOptions.ClientSecret,
            GrantType = GRANT_TYPE
        };
        var authorizationCodeFlow = new AuthorizationCodeFlow(new AuthorizationCodeFlow.Initializer(
            _googleCalendarCredentialsOptions.AuthUri,
            _googleCalendarCredentialsOptions.TokenUri
        )
        {
            ClientSecrets = new ClientSecrets()
            {
                ClientId = _googleCalendarCredentialsOptions.ClientId,
                ClientSecret = _googleCalendarCredentialsOptions.ClientSecret,
            },
        });
        var result = await authorizationCodeFlow.FetchTokenAsync(
            "mail@gmail.com", 
            authorizationCodeTokenRequest, 
            CancellationToken.None
        );
        var client = BuildClient(result.AccessToken);
        var calendarRequest = client.Calendars.Get("primary");
        var calendar = await calendarRequest.ExecuteAsync();
        var issuerName = calendar.Id;
        return new GoogleCalendarCredentialsResponse(
            issuerName, 
            result.AccessToken, 
            result.RefreshToken, 
            DateTime.Now.AddSeconds((double)result.ExpiresInSeconds!
            )
        );
    }
}