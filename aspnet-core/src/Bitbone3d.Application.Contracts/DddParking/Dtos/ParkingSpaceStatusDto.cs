using System;

namespace Bitbone3d.DddParking.Dtos;

public class ParkingSpaceStatusDto
{
    public string ParkingSpaceCode { get; set; } = default!;

    public bool IsAvailable { get; set; }

    public string? ParkingLicensePlateNo { get; set; }

    public DateTime? ParkedAt { get; set; }
}