﻿using System;
using Bitbone3d.Command;
using Volo.Abp.MultiTenancy;

namespace Bitbone3d.DddParking;

public class VehicleEnteredEvent : IDomainEvent, IMultiTenant
{
    public string LicensePlateNo { get; set; } = default!;

    public DateTime EntryTime { get; set; }
    public string EntryLane { get; set; } = default!;

    public DateTime HappenTime { get; set; }

    /// <summary>Id of the related tenant.</summary>
    public Guid? TenantId { get; set; }
}