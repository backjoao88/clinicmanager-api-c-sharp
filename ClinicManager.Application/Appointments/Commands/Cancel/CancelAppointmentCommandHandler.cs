using ClinicManager.Application.Appointments.Commands.Confirm;
using ClinicManager.Domain.Primitives;
using ClinicManager.Domain.Primitives.Errors;
using ClinicManager.Domain.Repositories;
using MediatR;

namespace ClinicManager.Application.Appointments.Commands.Cancel;

/// <summary>
/// Represents the <see cref="ConfirmAppointmentCommand"/> handler.
/// </summary>
public class CancelAppointmentCommandHandler : IRequestHandler<CancelAppointmentCommand, Result>
{
    private IUnitOfWork _unitOfWork;

    public CancelAppointmentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CancelAppointmentCommand request, CancellationToken cancellationToken)
    {
        var appointment = await _unitOfWork.AppointmentRepository.ReadByCode(request.Code);
        if (appointment is null)
        {
            return Result.Fail(AppointmentDomainErrors.AppointmentNotFound);
        }
        var cancelationResult = appointment.Cancel();
        if (cancelationResult.IsFailure)
        {
            return cancelationResult;
        }
        await _unitOfWork.Complete();
        return Result.Ok();
    }
}