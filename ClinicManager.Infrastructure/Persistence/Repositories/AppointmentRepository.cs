using ClinicManager.Domain.Core.Appointments;
using ClinicManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Infrastructure.Persistence.Repositories;

public class AppointmentRepository : IAppointmentRepository
{
    private readonly AppDbContext _context;

    public AppointmentRepository(AppDbContext context)
    {
        _context = context;
    }
    
    /// <inheriteddoc/>
    public async Task Add(Appointment entity)
    {
        await _context.Appointments.AddAsync(entity);
    }

    /// <inheriteddoc/>
    public async Task<Appointment?> ReadById(Guid id)
    {
        return await _context.Appointments.SingleOrDefaultAsync(o => o.Id == id);
    }
}