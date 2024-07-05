using System.ComponentModel.DataAnnotations;

namespace Bitbone3d.DddParking.Dtos;

public class ParkingSpaceUnparkInputDto
{
    [Required]
    [StringLength(ParkingConsts.MaxParkingSpaceCodeLength)]
    public string ParkingSpaceCode { get; set; } = default!;
}