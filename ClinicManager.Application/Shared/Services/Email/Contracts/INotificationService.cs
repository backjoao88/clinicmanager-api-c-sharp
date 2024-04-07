namespace ClinicManager.Application.Shared.Services.Email.Contracts;

/// <summary>
/// Contract to represent a notification service.
/// </summary>
public interface INotificationService
{
    /// <summary>
    /// Sends a message.
    /// </summary>
    /// <returns></returns>
    public Task Send(EmailMessage message);
}