using System;

namespace Bitbone3d.DddParking.Dtos;

public class ParkingDailyIncomeDto
{
    public DateTime Date { get; set; }

    public decimal Amount { get; set; }
}