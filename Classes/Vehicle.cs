namespace CarServiceDB.Classes;

public class Vehicle
{
    private readonly string? _licensePlate, _brand, _model, _color;

    public int VehiclesId { get; set; }

    public int VCustomersId { get; init; }

    public string? VehiclesLicensePlate
    {
        get => _licensePlate;
        init => _licensePlate = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string? VehiclesBrand
    {
        get => _brand;
        init => _brand = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string? VehiclesModel
    {
        get => _model;
        init => _model = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string? VehiclesColor
    {
        get => _color;
        init => _color = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int VehiclesYear { get; init; }

    public double VehiclesMileage { get; init; }

    public DateTime? VehiclesLastService { get; set; }
}