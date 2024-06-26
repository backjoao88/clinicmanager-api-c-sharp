﻿using ClinicManager.Domain.Primitives;
using MediatR;

namespace ClinicManager.Application.Appointments.Commands.Schedule;

/// <summary>
/// Represents the schedulling appointment command.
/// </summary>
public class ScheduleAppointmentCommand : IRequest<Result>
{
    public ScheduleAppointmentCommand(Guid idDoctor, Guid idPatient, Guid idSpeciality, DateOnly day, TimeOnly start, TimeOnly end)
    {
        IdDoctor = idDoctor;
        IdPatient = idPatient;
        IdSpeciality = idSpeciality;
        Day = day;
        Start = start;
        End = end;
    }
    public Guid IdDoctor { get; set; }
    public Guid IdPatient { get; set; }
    public Guid IdSpeciality { get; set; }
    public DateOnly Day { get; set; }
    public TimeOnly Start { get; set; }
    public TimeOnly End { get; set; }
}