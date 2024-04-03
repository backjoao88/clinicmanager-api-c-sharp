using ClinicManager.Domain.Core.Integration;
using ClinicManager.Domain.Repositories;
using ClinicManager.Domain.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Infrastructure.Persistence.Repositories;

/// <inheriteddoc/>
public class CredentialRepository : ICredentialRepository
{
    private readonly AppDbContext _context;

    public CredentialRepository(AppDbContext context)
    {
        _context = context;
    }

    /// <inheriteddoc/>
    public async Task Add(Credential entity)
    {
        await _context.Credentials.AddAsync(entity);
    }
    
    /// <inheriteddoc/>
    public async Task<Credential?> ReadById(Guid id)
    {
        return await _context.Credentials.SingleOrDefaultAsync(o => o.Id == id);
    }
}