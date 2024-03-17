using ClinicManager.Domain.Core;
using ClinicManager.Domain.Core.Appointments;
using ClinicManager.Domain.Core.Doctors;
using ClinicManager.Domain.Core.Patients;
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
    private AppDbContext()
    {
    }

    /// <summary>
    /// Base constructor.
    /// </summary>
    /// <param name="options"></param>
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Patient> Patients { get; set; } = null!;
    public DbSet<Doctor> Doctors { get; set; } = null!;
    public DbSet<Appointment> Appointments { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}