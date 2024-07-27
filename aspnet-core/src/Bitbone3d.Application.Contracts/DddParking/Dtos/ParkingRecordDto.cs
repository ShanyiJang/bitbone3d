using System;
using Volo.Abp.Application.Dtos;

namespace Bitbone3d.DddParking.Dtos;

public class ParkingRecordDto : EntityDto<Guid>
{
    public string LicensePlateNo { get; set; } = default!;

    public string EntryLane { get; set; } = default!;

    public DateTime EntryTime { get; set; }

    public string? LastParkingSpaceCode { get; set; }

    public bool Exited { get; set; }

    public DateTime? LastPayTime { get; set; }

    public decimal TotalPaidAmount { get; set; }

    public string? ExitLane { get; set; }

    public DateTime? ExitTime { get; set; }
}