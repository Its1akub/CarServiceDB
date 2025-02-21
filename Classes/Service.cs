namespace CarServiceDB.Classes;

public class Service
{
    private readonly string? _serviceName;

    public int ServiceId { get; set; }

    public string? ServiceName
    {
        get => _serviceName;
        init => _serviceName = value ?? throw new ArgumentNullException(nameof(value));
    }

    public decimal ServicePrice { get; set; }

    public double ServiceEstimatedTime { get; set; }

    public string? ServiceIsWarranty { get; set; }
}