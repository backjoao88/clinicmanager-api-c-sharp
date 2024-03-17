using ClinicManager.Domain.Core;
using ClinicManager.Domain.Core.Patients;
using ClinicManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Infrastructure.Persistence.Repositories;

/// <inheriteddoc/>
public class PatientRepository : IPatientRepository
{
    private readonly AppDbContext _context;

    public PatientRepository(AppDbContext context)
    {
        _context = context;
    }

    /// <inheriteddoc/>
    public async Task Add(Patient entity)
    {
        await _context.Patients.AddAsync(entity);
    }

    /// <inheriteddoc/>
    public async Task<Patient?> ReadById(Guid id)
    {
        return await _context.Patients.SingleOrDefaultAsync(o => o.Id == id);
    }
    
    /// <inheriteddoc/>
    public async Task<List<Patient>> ReadAll()
    {
        return await _context.Patients.ToListAsync();
    }
}