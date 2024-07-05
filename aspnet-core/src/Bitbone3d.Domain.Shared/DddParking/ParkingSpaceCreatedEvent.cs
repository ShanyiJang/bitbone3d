using System;
using Bitbone3d.Command;
using Volo.Abp.MultiTenancy;

namespace Bitbone3d.DddParking;

public class ParkingSpaceCreatedEvent : IDomainEvent, IMultiTenant
{
    public string ParkingSpaceCode { get; set; } = default!;

    public string? Location { get; set; }

    public string? Description { get; set; }

    public DateTime HappenTime { get; set; }

    /// <summary>Id of the related tenant.</summary>
    public Guid? TenantId { get; set; }
}