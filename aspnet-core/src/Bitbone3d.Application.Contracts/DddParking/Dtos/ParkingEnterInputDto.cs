using System.ComponentModel.DataAnnotations;

namespace Bitbone3d.DddParking.Dtos;

public class ParkingEnterInputDto
{
    [Required]
    [StringLength(ParkingConsts.MaxLicensePlateNoLength)]
    public string LicensePlateNo { get; set; } = default!;
    
    [Required]
    [StringLength(ParkingConsts.MaxEntryLaneLength)]
    public string EntryLane { get; set; } = default!;
}