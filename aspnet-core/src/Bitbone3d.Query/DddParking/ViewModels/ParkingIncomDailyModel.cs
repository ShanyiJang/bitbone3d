using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace Bitbone3d.DddParking.ViewModels;

public class ParkingIncomDailyModel : Entity<Guid>, IHasConcurrencyStamp, IMultiTenant
{
    public DateTime Date { get; private set; }

    public decimal TotalAmount { get; private set; }
    public string ConcurrencyStamp { get; set; } = default!;

    /// <summary>Id of the related tenant.</summary>
    public Guid? TenantId { get; private set; }

    private ParkingIncomDailyModel()
    {
    }

    public ParkingIncomDailyModel(Guid id, DateTime date, Guid? tenantId) : base(id)
    {
        Date = date;
        ConcurrencyStamp = Guid.NewGuid().ToString("N");
        TenantId = tenantId;
    }

    public void Add(decimal payAmount)
    {
        TotalAmount += payAmount;
    }
}