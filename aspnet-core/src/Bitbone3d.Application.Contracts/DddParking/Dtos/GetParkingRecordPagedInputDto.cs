using System;
using Volo.Abp.Application.Dtos;

namespace Bitbone3d.DddParking.Dtos;

public class GetParkingRecordPagedInputDto : PagedAndSortedResultRequestDto
{
    public string? LicensePlateNo { get; set; }
    public string? EntryLane { get; set; }
    public string? ExitLane { get; set; }
    public DateTime? StartEntryTime { get; set; }
    public DateTime? EndEntryTime { get; set; }
    public DateTime? StartExitTime { get; set; }
    public DateTime? EndExitTime { get; set; }
}