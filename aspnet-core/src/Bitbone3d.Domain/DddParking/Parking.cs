using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace Bitbone3d.DddParking;

public class Parking : AggregateRoot<Guid>, IMultiTenant
{
    public string LicensePlateNo { get; private set; } = default!;
    public string EntryLane { get; private set; } = default!;

    public DateTime EntryTime { get; private set; }

    public decimal PaidAmount { get; private set; }

    public DateTime? LastPayTime { get; private set; }

    /// <summary>Id of the related tenant.</summary>
    public Guid? TenantId { get; private set; }

    protected Parking()
    {
    }

    internal Parking(
        Guid id,
        string licensePlateNo,
        string entryLane,
        DateTime entryTime,
        Guid? tenantId
    ) : base(id)
    {
        LicensePlateNo = licensePlateNo;
        EntryLane = entryLane;
        EntryTime = entryTime;
        TenantId = tenantId;

        AddLocalEvent(
            new VehicleEnteredEvent
            {
                LicensePlateNo = licensePlateNo,
                EntryLane = entryLane,
                EntryTime = EntryTime,
                HappenTime = entryTime,
                TenantId = TenantId
            }
        );
    }

    internal void Pay(decimal amount, DateTime payTime)
    {
        PaidAmount += amount;
        LastPayTime = payTime;

        AddLocalEvent(
            new ParkingFeePaidEvent
            {
                LicensePlateNo = LicensePlateNo,
                PayAmount = amount,
                EntryTime = EntryTime,
                HappenTime = payTime,
                TenantId = TenantId
            }
        );
    }
}