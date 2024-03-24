using ClinicManager.Application.Shared;
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

    public SendConfirmationEmailEventHandler(INotificationService notificationService, IUnitOfWork unitOfWork)
    {
        _notificationService = notificationService;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(AppointmentScheduledDomainEvent notification, CancellationToken cancellationToken)
    {
        var patient = await _unitOfWork.PatientRepository.ReadById(notification.IdPatient);
        var doctor = await _unitOfWork.DoctorRepository.ReadById(notification.IdDoctor);
        if (patient is null) return;
        if (doctor is null) return;
        EmailMessage emailMessage =
            new EmailMessage(
                (patient.FirstName + " " + patient.LastName).ToUpper(),
                (doctor.FirstName + " " + doctor.LastName).ToUpper(),
                "backdevbmsoft@gmail.com",
                "Confirmação de atendimento médico",
                notification.Day,
                notification.Start,
                notification.End
            );
        await _notificationService.Send(emailMessage);
    }
}