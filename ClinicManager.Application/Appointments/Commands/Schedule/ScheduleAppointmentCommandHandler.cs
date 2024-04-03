using ClinicManager.Domain.Core.Appointments;
using ClinicManager.Domain.Primitives;
using ClinicManager.Domain.Primitives.Errors;
using ClinicManager.Domain.Repositories;
using MediatR;

namespace ClinicManager.Application.Appointments.Commands.Schedule;

/// <summary>
/// Represents the <see cref="ScheduleAppointmentCommand"/> handler.
/// </summary>
public class ScheduleAppointmentCommandHandler : IRequestHandler<ScheduleAppointmentCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public ScheduleAppointmentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Result> Handle(ScheduleAppointmentCommand request, CancellationToken cancellationToken)
    {
        var doctor = await _unitOfWork.DoctorRepository.ReadById(request.IdDoctor);
        if (doctor is null)
        {
            return Result.Fail(DoctorDomainErrors.DoctorNotFound);
        }
        var patient = await _unitOfWork.PatientRepository.ReadById(request.IdPatient);
        if (patient is null)
        {
            return Result.Fail(PatientDomainErrors.PatientNotFound);
        }
        var availableDay = await _unitOfWork.DoctorRepository.ReadScheduleDay(request.Day);
        if (availableDay is null)
        {
            return Result.Fail(DoctorDomainErrors.DoctorNotAvailable);
        }
        if (availableDay.IsBusy(request.Start, request.End))
        {
            return Result.Fail(DoctorDomainErrors.DoctorNotAvailable);
        }
        var appointmentStart = new DateTime(availableDay.Day, request.Start);
        var appointmentEnd = new DateTime(availableDay.Day, request.End);
        var appointment = Appointment.Create(request.IdDoctor, request.IdPatient, appointmentStart, appointmentEnd);
        await _unitOfWork.AppointmentRepository.Add(appointment);
        await _unitOfWork.Complete();
        return Result.Ok();
    }
}