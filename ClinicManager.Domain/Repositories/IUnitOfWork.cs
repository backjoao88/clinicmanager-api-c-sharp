namespace ClinicManager.Domain.Repositories;

/// <summary>
/// Represents the unit of work pattern.
/// </summary>
public interface IUnitOfWork
{
    public IPatientRepository PatientRepository { get; set; }
    public IDoctorRepository DoctorRepository { get; set; }
    public IAppointmentRepository AppointmentRepository { get; set; }
    /// <summary>
    /// Completes a transaction.
    /// </summary>
    /// <returns></returns>
    public Task<int> Complete();
}