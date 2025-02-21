namespace CarServiceDB.Classes;

public class Repair
{
    public int RepairId { get; set; }

    public int RVehiclesId { get; set; }

    public int RServiceId { get; set; }

    public DateTime RepairRepairDate { get; set; }

    public double RepairTotalCost { get; set; }

    public string? RepairIsCompleted { get; set; }
}