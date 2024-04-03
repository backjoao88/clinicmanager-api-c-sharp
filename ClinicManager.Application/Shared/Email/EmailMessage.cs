using ClinicManager.Application.Shared.Email.Contracts;

namespace ClinicManager.Application.Shared.Email;

/// <summary>
/// Represents and email body.
/// </summary>
public class EmailBody
{
    public EmailBody(string patientName, string doctorName, DateOnly eventDay, TimeOnly eventStart, TimeOnly eventEnd, string confirmationLink, string cancelationLink)
    {
        PatientName = patientName;
        DoctorName = doctorName;
        EventDay = eventDay;
        EventStart = eventStart;
        EventEnd = eventEnd;
        ConfirmationLink = confirmationLink;
        CancelationLink = cancelationLink;
    }
    public string PatientName { get; set; }
    public string DoctorName { get; set; }
    public DateOnly EventDay { get; set; }
    public TimeOnly EventStart { get; set; }
    public TimeOnly EventEnd { get; set; }
    public string ConfirmationLink { get; set; }
    public string CancelationLink { get; set; }
}

/// <summary>
/// Represents a notification message from <see cref="INotificationService"/> service.
/// </summary>
public class EmailMessage
{
    public EmailMessage(string subject, string destinatary, EmailBody body)
    {
        Subject = subject;
        Destinatary = destinatary;
        Body = body;
    }
    public string Subject { get; set; }
    public string Destinatary { get; set; }
    public EmailBody Body { get; set; }
}