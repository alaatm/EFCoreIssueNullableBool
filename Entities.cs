namespace EFCoreIssueNullableBool;

public class Vehicle
{
    public int Id { get; set; }
    public VehicleRegistration Registration { get; set; } = default!;
}

public class VehicleRegistration
{
    public int Id { get; set; }
    public bool? Approved { get; set; }
}