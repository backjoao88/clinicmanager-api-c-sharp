using ClinicManager.Domain.Core.Appointments;
using ClinicManager.Domain.Core.Doctors;
using ClinicManager.Domain.Core.Doctors.Schedules;
using ClinicManager.Domain.Core.Integration;
using ClinicManager.Domain.Core.Patients;
using ClinicManager.Domain.Core.Users;
using ClinicManager.Domain.Primitives;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Infrastructure.Persistence;

/// <summary>
/// Represents a context to access the database.
/// </summary>
public class AppDbContext : DbContext
{
    /// <summary>
    /// Required by EFCore.
    /// </summary>
    private AppDbContext(IPublisher publisher)
    {
        _publisher = publisher;
    }

    /// <summary>
    /// Base constructor.
    /// </summary>
    /// <param name="options"></param>
    /// <param name="publisher"></param>
    public AppDbContext(DbContextOptions options, IPublisher publisher) : base(options)
    {
        _publisher = publisher;
    }

    /// <summary>
    /// MediatR publisher property.
    /// </summary>
    private readonly IPublisher _publisher;

    public DbSet<Patient> Patients { get; set; } = null!;
    public DbSet<Doctor> Doctors { get; set; } = null!;
    public DbSet<Appointment> Appointments { get; set; } = null!;
    public DbSet<Schedule> Schedules { get; set; } = null!;
    public DbSet<ScheduleDay> SchedulesDays { get; set; } = null!;
    public DbSet<BusySlot> Slots { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<AppointmentCode> AppointmentCodes { get; set; } = null!;
    public DbSet<Credential> Credentials { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    /// <summary>
    /// Overrided save changes that publishes all messages before saving changes.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default!)
    {
        var events = ChangeTracker
            .Entries<Entity>()
            .SelectMany(o => o.Entity.Events);
        foreach(var ev in events)
        {
            await _publisher.Publish(ev);
        }
        return await base.SaveChangesAsync(cancellationToken);
    }
}