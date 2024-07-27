using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace Bitbone3d.DddParking;

public class ParkingSpace : AggregateRoot<Guid>, IMultiTenant
{
    public string Code { get; private set; } = default!;

    public string? ParkingLicensePlateNo { get; private set; }

    /// <summary>Id of the related tenant.</summary>
    public Guid? TenantId { get; private set; }

    private ParkingSpace()
    {
    }

    internal ParkingSpace(Guid id, string code, Guid? tenantId) : base(id)
    {
        Code = code;
        TenantId = tenantId;
    }

    internal void Park(string licensePlateNo, DateTime entryTime, DateTime parkedAt)
    {
        if (!ParkingLicensePlateNo.IsNullOrEmpty())
        {
            Unpark(parkedAt);
        }

        ParkingLicensePlateNo = licensePlateNo;

        AddLocalEvent(
            new VehicleParkedEvent
            {
                ParkingSpaceCode = Code,
                LicensePlateNo = licensePlateNo,
                EntryTime = entryTime,
                HappenTime = parkedAt,
                TenantId = TenantId
            }
        );
    }

    internal void Unpark(DateTime deparkedAt)
    {
        if (!ParkingLicensePlateNo.IsNullOrEmpty())
        {
            AddLocalEvent(
                new VehicleDeparkedEvent
                {
                    ParkingSpaceCode = Code,
                    LicensePlateNo = ParkingLicensePlateNo,
                    HappenTime = deparkedAt,
                    TenantId = TenantId,
                }
            );
        }
        
        ParkingLicensePlateNo = null;
    }
}