using System.Dynamic;
using ClinicManager.Domain.Primitives;

namespace ClinicManager.Domain.Core.Appointments;

/// <summary>
/// Represents an confirmation code.
/// </summary>
public class AppointmentCode : Entity
{
    private AppointmentCode(Guid idAppointment, Guid code, DateTime expiration)
    {
        Id = Guid.NewGuid();
        Used = false;
        IdAppointment = idAppointment;
        Code = code;
        Expiration = expiration;
    }
    public Guid IdAppointment { get; private set; }
    public Guid Code { get; private set; }
    public DateTime Expiration { get; private set; }
    public bool Used { get; private set; }

    /// <summary>
    /// Use a built token.
    /// </summary>
    /// <returns></returns>
    public void Use()
    {
        Used = true;
    }

    /// <summary>
    /// Creates a new token.
    /// </summary>
    /// <returns></returns>
    public static AppointmentCode CreateFiveMinutesToken(Guid idAppointment)
    {
        const int EXPIRATION_IN_MINUTES = 5;
        return new AppointmentCode(
            idAppointment,
            Guid.NewGuid(),
            DateTime.Now.AddMinutes(EXPIRATION_IN_MINUTES)
        );
    }

    /// <summary>
    /// Checks if someone can use the token.
    /// </summary>
    /// <returns></returns>
    public bool CanUse()
    {
        return Expiration > DateTime.Now && !Used;
    }
}