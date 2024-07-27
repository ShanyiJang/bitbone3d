namespace Bitbone3d.DddParking.Dtos;

public class ParkingVehiclePositionDto
{
    public bool IsVehiclePresent { get; set; }

    public string? ParkingSpaceCode { get; set; }

    public string? Location { get; set; }

    public string? Description { get; set; }
}