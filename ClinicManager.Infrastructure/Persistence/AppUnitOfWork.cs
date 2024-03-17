using ClinicManager.Domain.Repositories;

namespace ClinicManager.Infrastructure.Persistence;

/// <inheritdoc/>>
public class AppUnitOfWork : IUnitOfWork
{
    public AppUnitOfWork(IPatientRepository patientRepository, IDoctorRepository doctorRepository, IAppointmentRepository appointmentRepository,  AppDbContext appDbContext)
    {
        PatientRepository = patientRepository;
        DoctorRepository = doctorRepository;
        _appDbContext = appDbContext;
        AppointmentRepository = appointmentRepository;
    }
    public IPatientRepository PatientRepository { get; set; }
    public IDoctorRepository DoctorRepository { get; set; }
    public IAppointmentRepository AppointmentRepository { get; set; }
    private readonly AppDbContext _appDbContext;
    
    /// <inheritdoc/>>
    public async Task<int> Complete()
    {
        return await _appDbContext.SaveChangesAsync();
    }
}