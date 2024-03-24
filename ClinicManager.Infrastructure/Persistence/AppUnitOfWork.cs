using ClinicManager.Domain.Repositories;

namespace ClinicManager.Infrastructure.Persistence;

/// <inheritdoc/>>
public class AppUnitOfWork : IUnitOfWork
{
    public AppUnitOfWork(AppDbContext appDbContext, IPatientRepository patientRepository, IDoctorRepository doctorRepository, IAppointmentRepository appointmentRepository,  IUserRepository userRepository)
    {
        _appDbContext = appDbContext;
        PatientRepository = patientRepository;
        DoctorRepository = doctorRepository;
        UserRepository = userRepository;
        AppointmentRepository = appointmentRepository;
    }
    public IPatientRepository PatientRepository { get; set; }
    public IDoctorRepository DoctorRepository { get; set; }
    public IAppointmentRepository AppointmentRepository { get; set; }
    public IUserRepository UserRepository { get; set; }
    
    private readonly AppDbContext _appDbContext;
    
    /// <inheritdoc/>>
    public async Task<int> Complete()
    {
        return await _appDbContext.SaveChangesAsync();
    }
}