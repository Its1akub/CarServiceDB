namespace CarServiceDB.Classes;

public class Mechanic
{
    private readonly string? _name, _surname;
    private string? _specialization;

    public int MechanicId { get; set; }

    public string? MechanicName
    {
        get => _name;
        init => _name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string? MechanicSurname
    {
        get => _surname;
        init => _surname = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string? MechanicSpecialization
    {
        get => _specialization;
        set => _specialization = value ?? throw new ArgumentNullException(nameof(value));
    }

    public double MechanicHourlyRate { get; set; }

    public DateTime MechanicEmploymentDate { get; set; }

    public string? MechanicIsActive { get; set; }
}