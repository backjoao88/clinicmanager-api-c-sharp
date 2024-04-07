using ClinicManager.Application.Shared.Services.GoogleCalendar;
using ClinicManager.Application.Shared.Services.GoogleCalendar.Dtos;
using ClinicManager.Domain.Core.Appointments.Events;
using ClinicManager.Domain.Repositories;
using MediatR;

namespace ClinicManager.Application.Appointments.Events;

/// <summary>
/// Event handler for adding an event in Google Calendar Api after an appointment was scheduled.
/// </summary>
public class AddGoogleCalendarEventHandler : INotificationHandler<AppointmentScheduledDomainEvent>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGoogleCalendarService _googleCalendarService;

    public AddGoogleCalendarEventHandler(IUnitOfWork unitOfWork, IGoogleCalendarService googleCalendarService)
    {
        _unitOfWork = unitOfWork;
        _googleCalendarService = googleCalendarService;
    }

    public async Task Handle(AppointmentScheduledDomainEvent notification, CancellationToken cancellationToken)
    {

        var doctor = await _unitOfWork.DoctorRepository.ReadById(notification.IdDoctor);
        if (doctor is null)
        {
            Console.WriteLine($"[log] GoogleCalendarHandler -> Doctor {notification.IdPatient} not found. Event will not be addded.");
            return;
        }
        var patient = await _unitOfWork.PatientRepository.ReadById(notification.IdPatient);
        if (patient is null)
        {
            Console.WriteLine($"[log] GoogleCalendarHandler -> Patient {notification.IdPatient} not found. Event will not be addded.");
            return;
        }
        
        var credentials = await _unitOfWork.CredentialRepository.ReadByEmail(doctor.Email);
        if (credentials is null)
        {
            Console.WriteLine($"[log] GoogleCalendarHandler -> Credentials of {doctor.Email} not found. Event will not be addded.");
            return;
        }

        string defaultSummary = $"CONSULTA MÉDICA - DR {doctor.FirstName}";
        string defaultDescription = "CONSULTA MÉDICA";
        
        string[] attendees = { patient.Email };
        
        //if (credentials.IsExpired())
        {
            var googleCredentialsResponse = await _googleCalendarService.RefreshToken(credentials.RefreshToken);
            credentials.Update(googleCredentialsResponse.AccessToken, googleCredentialsResponse.Expiration);
        }
        
        var eventRequest = new GoogleCalendarEventRequest(
            credentials.AccessToken,
            "primary",
            defaultSummary,
            defaultDescription,
            attendees,
            new DateTime(notification.Day, notification.Start),
            new DateTime(notification.Day, notification.End)
        );

        try
        {
            await _googleCalendarService.CreateEvent(eventRequest);
        }
        catch (Exception exception)
        {
            Console.WriteLine($"[log] GoogleCalendarHandler -> {exception.Message}");
        }
    }
}