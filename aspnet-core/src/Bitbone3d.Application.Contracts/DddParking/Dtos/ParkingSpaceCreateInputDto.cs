using System.ComponentModel.DataAnnotations;

namespace Bitbone3d.DddParking.Dtos;

public class ParkingSpaceCreateInputDto
{
    [Required]
    [StringLength(ParkingConsts.MaxParkingSpaceCodeLength)]
    public string ParkingSpaceCode { get; set; } = default!;

    [StringLength(ParkingConsts.MaxParkingSpaceLocationLength)]
    public string? Location { get; set; }

    [StringLength(ParkingConsts.MaxParkingSpaceDescriptionLength)]
    public string? Description { get; set; }
}