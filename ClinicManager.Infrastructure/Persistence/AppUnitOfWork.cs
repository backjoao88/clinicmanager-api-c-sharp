using ClinicManager.Domain.Repositories;

namespace ClinicManager.Infrastructure.Persistence;

/// <inheritdoc/>>
public class AppUnitOfWork : IUnitOfWork
{
    public AppUnitOfWork(IPatientRepository patientRepository, IDoctorRepository doctorRepository, AppDbContext appDbContext)
    {
        PatientRepository = patientRepository;
        DoctorRepository = doctorRepository;
        _appDbContext = appDbContext;
    }
    public IPatientRepository PatientRepository { get; set; }
    public IDoctorRepository DoctorRepository { get; set; }
    private readonly AppDbContext _appDbContext;
    
    /// <inheritdoc/>>
    public async Task<int> Complete()
    {
        return await _appDbContext.SaveChangesAsync();
    }
}