namespace ClinicManager.Application.Shared.Services.Email;

/// <summary>
/// Sets up an email calendar event.
/// </summary>
public class IcsMessage
{
    public IcsMessage(string summary, string description, DateOnly day, TimeOnly start, TimeOnly end)
    {
        Summary = summary;
        Description = description;
        Day = day;
        Start = start;
        End = end;
    }
    public string Summary { get; set; }
    public string Description { get; set; }
    public DateOnly Day { get; set; }
    public TimeOnly Start { get; set; }
    public TimeOnly End { get; set; }
}