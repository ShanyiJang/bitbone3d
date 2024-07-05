using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace Bitbone3d.DddParking.ViewModels;

public class ParkingRecordModel : Entity<Guid>, IHasConcurrencyStamp, IMultiTenant
{
    public string LicensePlateNo { get; private set; } = default!;

    public string EntryLane { get; private set; } = default!;

    public DateTime EntryTime { get; private set; }

    public string? LastParkingSpaceCode { get; private set; }

    public bool Exited { get; private set; }

    public DateTime? LastPayTime { get; private set; }

    public decimal TotalPaidAmount { get; private set; }

    public string? ExitLane { get; private set; }

    public DateTime? ExitTime { get; private set; }

    public string ConcurrencyStamp { get; set; } = default!;

    /// <summary>Id of the related tenant.</summary>
    public Guid? TenantId { get; private set; }

    private ParkingRecordModel()
    {
    }

    public ParkingRecordModel(
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
        ConcurrencyStamp = Guid.NewGuid().ToString("N");
        TenantId = tenantId;
    }

    public void Park(string parkingSpaceCode)
    {
        if (Exited)
        {
            throw new UserFriendlyException($"停车记录 {Id} 状态异常，泊车失败！");
        }

        LastParkingSpaceCode = parkingSpaceCode;
    }

    public void Pay(decimal amount, DateTime payTime)
    {
        if (Exited)
        {
            throw new UserFriendlyException($"停车记录 {Id} 状态异常，付费失败！");
        }

        TotalPaidAmount += amount;
        if (payTime > LastPayTime)
        {
            LastPayTime = payTime;
        }
    }

    public void Exit(string exitLane, DateTime exitTime)
    {
        if (Exited)
        {
            throw new UserFriendlyException($"停车记录 {Id} 状态异常，出场失败！");
        }

        ExitLane = exitLane;
        ExitTime = exitTime;
    }
}