using System;

namespace Bitbone3d.DddParking.Services.Billing;

public class FeeCalculationRequest
{
    public DateTime EntryTime { get; set; }
    public DateTime? ExitTime { get; set; }
}