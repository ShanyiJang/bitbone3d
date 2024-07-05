using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace Bitbone3d.DddParking.ViewModels;

public class InParkVehicleCounterModel : Entity<Guid>, IHasConcurrencyStamp, IMultiTenant
{
    public int Count { get; private set; }
    public string ConcurrencyStamp { get; set; } = default!;

    /// <summary>Id of the related tenant.</summary>
    public Guid? TenantId { get; private set; }

    public void Enter() => Count++;

    public void Exit() => Count--;

    private InParkVehicleCounterModel()
    {
    }

    public InParkVehicleCounterModel(Guid id, Guid? tenantId) : base(id)
    {
        TenantId = tenantId;
        ConcurrencyStamp = Guid.NewGuid().ToString("N");
    }
}