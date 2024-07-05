using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace Bitbone3d.DddParking.ViewModels;

public class ParkingSpaceMonitorModel : Entity<Guid>, IHasConcurrencyStamp, IMultiTenant
{
    public string ParkingSpaceCode { get; private set; } = default!;

    public string? Location { get; private set; }

    public string? Description { get; private set; }

    public bool IsAvailable { get; private set; } = true;

    public string? ParkingLicensePlateNo { get; private set; }

    public DateTime? ParkedAt { get; private set; }

    public string ConcurrencyStamp { get; set; } = default!;

    /// <summary>Id of the related tenant.</summary>
    public Guid? TenantId { get; private set; }

    private ParkingSpaceMonitorModel()
    {
    }

    public ParkingSpaceMonitorModel(
        Guid id,
        string parkingSpaceCode,
        string? location,
        string? description,
        Guid? tenantId
    ) : base(id)
    {
        ParkingSpaceCode = parkingSpaceCode;
        Location = location;
        Description = description;
        IsAvailable = true;
        ConcurrencyStamp = Guid.NewGuid().ToString("N");
        TenantId = tenantId;
    }

    public void Park(string licensePlateNo, DateTime parkedAt)
    {
        ParkingLicensePlateNo = licensePlateNo;
        ParkedAt = parkedAt;
        IsAvailable = false;
    }

    public void Unpark()
    {
        ParkingLicensePlateNo = null;
        ParkedAt = null;
        IsAvailable = true;
    }
}