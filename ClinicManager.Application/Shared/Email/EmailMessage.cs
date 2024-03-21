using ClinicManager.Application.Shared.Email.Contracts;

namespace ClinicManager.Application.Shared.Email;

/// <summary>
/// Represents a notification message from <see cref="INotificationService"/> service.
/// </summary>
public class EmailMessage
{
    public EmailMessage(string name, string doctorName, string destinatary, string subject,DateOnly day, TimeOnly eventStart, TimeOnly eventEnd)
    {
        Name = name;
        DoctorName = doctorName;
        Destinatary = destinatary;
        Subject = subject;
        Day = day;
        EventStart = eventStart;
        EventEnd = eventEnd;
    }
    public string Name { get; set; }
    public string DoctorName { get; set; }
    public string Destinatary { get; set; }
    public string Subject { get; set; }
    public DateOnly Day { get; set; }
    public TimeOnly EventStart { get; set; }
    public TimeOnly EventEnd { get; set; }
}