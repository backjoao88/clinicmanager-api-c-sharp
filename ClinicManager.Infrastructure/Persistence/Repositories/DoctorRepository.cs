using ClinicManager.Domain.Core.Doctors;
using ClinicManager.Domain.Core.Doctors.Schedules;
using ClinicManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Infrastructure.Persistence.Repositories;

/// <inheriteddoc/>
public class DoctorRepository : IDoctorRepository
{
    private readonly AppDbContext _context;

    public DoctorRepository(AppDbContext context)
    {
        _context = context;
    }

    /// <inheriteddoc/>
    public async Task Add(Doctor entity)
    {
        await _context.Doctors.AddAsync(entity);
    }

    /// <inheriteddoc/>
    public async Task<Doctor?> ReadById(Guid id)
    {
        return await _context
            .Doctors
            .SingleOrDefaultAsync(o => o.Id == id);
    }
    
    /// <inheriteddoc/>
    public async Task<List<Doctor>> ReadAll()
    {
        return await _context
            .Doctors
            .ToListAsync();
    }

    public async Task AddSchedule(Schedule schedule)
    {
        await _context
            .Schedules
            .AddAsync(schedule);
    }

    public async Task AddBusySlot(Slot slot)
    {
        await _context
            .Slots
            .AddAsync(slot);
    }

    public async Task<ScheduleDay?> ReadScheduleDay(DateOnly date)
    {
        return await _context
            .SchedulesDays
            .SingleOrDefaultAsync(o => o.Day == date);
    }
}