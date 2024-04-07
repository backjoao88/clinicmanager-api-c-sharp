using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using ClinicManager.Application.Shared;
using ClinicManager.Application.Shared.Services.Email;
using ClinicManager.Application.Shared.Services.Email.Contracts;
using ClinicManager.Infrastructure.Services.Email.Options;
using Microsoft.Extensions.Options;
using RazorEngine;
using RazorEngine.Configuration;
using RazorEngine.Templating;
using Attachment = System.Net.Mail.Attachment;

namespace ClinicManager.Infrastructure.Services.Email;

/// <inheritdoc/>>
public class EmailNotificationService : INotificationService
{
    private readonly EmailOptions _emailOptions;
    private readonly IIcsProvider _icsProvider;

    public EmailNotificationService(IOptions<EmailOptions> emailOptions, IIcsProvider icsProvider)
    {
        _icsProvider = icsProvider;
        _emailOptions = emailOptions.Value;
    }

    /// <summary>
    /// Creates a new mail message.
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    private async Task<MailMessage> CreateMailMessage(EmailMessage message)
    {
        string templateFilePath = Path.Combine("..", "ClinicManager.Infrastructure", "Services", "Email", "Templates", "appointment-template.cshtml");
        string templateString = File.ReadAllText(templateFilePath);
        var result = Engine
            .Razor
            .RunCompile(templateString, Guid.NewGuid().ToString(), typeof(EmailBody), message.Body);
        
        const string APPOINTMENT_SUMMARY = "Convite para atendimento médico";
        const string APPOINTMENT_DESCRIPTION = "";
        ContentType attachmentContentType = new ContentType("text/calendar");
        var mailMessage = new MailMessage();
        mailMessage.From = new MailAddress(_emailOptions.Email, _emailOptions.Name);
        mailMessage.Subject = message.Subject;
        
        var calendarEvent = new IcsMessage(
            APPOINTMENT_SUMMARY,
            APPOINTMENT_DESCRIPTION,
            message.Body.EventDay,
            message.Body.EventStart,
            message.Body.EventEnd
        );
        
        var icsString = await _icsProvider.Generate(calendarEvent);
        var eventAttachment = Attachment.CreateAttachmentFromString(icsString, attachmentContentType);
        //mailMessage.Attachments.Add(eventAttachment); como integrei pelo agendas, não adiciona o ics aqui
        mailMessage.To.Add(message.Destinatary);
        mailMessage.IsBodyHtml = true;
        mailMessage.Body = result;
        
        return mailMessage;
    }

    /// <inheritdoc/>>
    public async Task Send(EmailMessage message)
    {
        using (var smtp = new SmtpClient())
        {
            var emailMessage = await CreateMailMessage(message);
            smtp.Host = _emailOptions.Host;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(_emailOptions.Email, _emailOptions.Password);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            await smtp.SendMailAsync(emailMessage);
        }
    }
}