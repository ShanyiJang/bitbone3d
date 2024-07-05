using System.ComponentModel.DataAnnotations;

namespace Bitbone3d.DddParking.Dtos;

public class ParkingSpaceParkInInputDto
{
    [Required]
    [StringLength(ParkingConsts.MaxParkingSpaceCodeLength)]
    public string ParkingSpaceCode { get; set; } = default!;

    [Required]
    [StringLength(ParkingConsts.MaxLicensePlateNoLength)]
    public string LicensePlateNo { get; set; } = default!;
}