using ClinicManager.Domain.Primitives;
using ClinicManager.Domain.Primitives.Errors;
using ClinicManager.Domain.Repositories;
using MediatR;

namespace ClinicManager.Application.Appointments.Commands.Confirm;

/// <summary>
/// Represents the <see cref="ConfirmAppointmentCommand"/> handler.
/// </summary>
public class ConfirmAppointmentCommandHandler : IRequestHandler<ConfirmAppointmentCommand, Result>
{
    private IUnitOfWork _unitOfWork;

    public ConfirmAppointmentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(ConfirmAppointmentCommand request, CancellationToken cancellationToken)
    {
        var appointment = await _unitOfWork.AppointmentRepository.ReadById(request.Id);
        if (appointment is null)
        {
            return Result.Fail(AppointmentDomainErrors.AppointmentNotFound);
        }
        appointment.Confirm();
        await _unitOfWork.Complete();
        return Result.Ok();
    }
}