using System;
using System.ComponentModel.DataAnnotations;

namespace Bitbone3d.DddParking.Dtos;

public class GetParkingDailyIncomeListInputDto
{
    [Required]
    public DateTime StartDate { get; set; }
    
    [Required]
    public DateTime EndDate { get; set; }
}