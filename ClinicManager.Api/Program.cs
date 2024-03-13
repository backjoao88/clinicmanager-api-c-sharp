using ClinicManager.Application;
using ClinicManager.Infrastructure;

namespace ClinicManager.Api;

public abstract class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddPersistence();
        builder.Services.AddApplication();
        var app = builder.Build();
        app.MapControllers();
        app.Services.RunMigrations();
        app.Run();
    }
}