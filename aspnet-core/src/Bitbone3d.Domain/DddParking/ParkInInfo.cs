using System;

namespace Bitbone3d.DddParking;

public class ParkInInfo
{
    public string ParkingSpaceCode { get; set; } = default!;

    public string LicensePlateNo { get; set; } = default!;

    public DateTime ParkInTime { get; set; }
}