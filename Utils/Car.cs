namespace Utils;

public record class Car
{
    public Guid Id { get; init; }
    public string Make { get; init; }
    public string Model { get; init; }
    public int Year { get; init; }
    public string Color { get; init; }
    public string LicensePlate { get; init; }
    public int NumberOfDoors { get; init; }
    public double CurrentSpeed { get; init; }
    public bool IsEngineRunning { get; init; }
    public double EngineSize { get; init; }
    public int HorsePower { get; init; }
    public FuelType FuelType { get; init; }
    public double FuelLevel { get; init; }
}