using ClinicManager.Application.Appointments.Services.Contracts;
using ClinicManager.Application.Shared.Email;
using ClinicManager.Application.Shared.Email.Contracts;
using ClinicManager.Domain.Core.Appointments.Events;
using ClinicManager.Domain.Primitives.Contracts;
using ClinicManager.Domain.Repositories;

namespace ClinicManager.Application.Appointments.Events;

/// <summary>
/// Represents one of the <see cref="AppointmentScheduledDomainEvent"/> handlers.
/// </summary>
public class SendConfirmationEmailEventHandler : IDomainEventHandler<AppointmentScheduledDomainEvent>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly INotificationService _notificationService;
    private readonly ILinkProvider _linkProvider;

    public SendConfirmationEmailEventHandler(INotificationService notificationService, IUnitOfWork unitOfWork, ILinkProvider linkProvider)
    {
        _notificationService = notificationService;
        _unitOfWork = unitOfWork;
        _linkProvider = linkProvider;
    }

    public async Task Handle(AppointmentScheduledDomainEvent notification, CancellationToken cancellationToken)
    {
        var patient = await _unitOfWork.PatientRepository.ReadById(notification.IdPatient);
        var doctor = await _unitOfWork.DoctorRepository.ReadById(notification.IdDoctor);
        if (patient is null) return;
        if (doctor is null) return;

        var confirmationLink = _linkProvider.GenerateConfirmationLink(notification.ConfirmationCode);
        var cancelationLink = _linkProvider.GenerateCancelationLink(notification.ConfirmationCode);
        
        await _notificationService.Send(new EmailMessage(
            "Confirmação de atendimento médico",
            patient.Email,
            new EmailBody(
                patient.FirstName, 
                doctor.FirstName, 
                notification.Day,
                notification.Start,
                notification.End,
                confirmationLink.BuildLink(),
                cancelationLink.BuildLink())
        ));
    }
}