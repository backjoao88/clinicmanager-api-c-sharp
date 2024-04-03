namespace ClinicManager.Application.Shared.GoogleCalendar.Dtos;

/// <summary>
/// Represents an authentication response from Google Calendar API.
/// </summary>
public record GoogleCalendarCredentialsResponse(string Issuer, string AccessToken, string RefreshToken, DateTime Expiration);