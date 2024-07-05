using Bitbone3d.DddParking.ViewModels;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Bitbone3d.DddParking;

public static class ParkingDbContextModelBuilderExtensions
{
    public static void ConfigureParking(
        this ModelBuilder builder
    )
    {
        Check.NotNull(builder, nameof(builder));

        builder.Entity<Parking>(
            b =>
            {
                b.ToTable(Bitbone3dConsts.ParkingDbTablePrefix + "Parkings", Bitbone3dConsts.DbSchema);

                b.ConfigureByConvention();

                b.Property(x => x.LicensePlateNo).HasMaxLength(ParkingConsts.MaxLicensePlateNoLength).IsRequired();
                b.Property(x => x.EntryLane).HasMaxLength(ParkingConsts.MaxEntryLaneLength).IsRequired();
                b.Property(x => x.EntryTime).IsRequired();
                b.Property(x => x.PaidAmount).HasPrecision(20, 6).IsRequired();
                b.Property(x => x.LastPayTime);

                b.HasIndex(x => new { x.TenantId, x.LicensePlateNo }).IsUnique();

                b.ApplyObjectExtensionMappings();
            }
        );

        builder.Entity<ParkingSpace>(
            b =>
            {
                b.ToTable(Bitbone3dConsts.ParkingDbTablePrefix + "ParkingSpaces", Bitbone3dConsts.DbSchema);

                b.ConfigureByConvention();

                b.Property(x => x.Code).HasMaxLength(ParkingConsts.MaxParkingSpaceCodeLength).IsRequired();
                b.Property(x => x.ParkingLicensePlateNo).HasMaxLength(ParkingConsts.MaxLicensePlateNoLength);

                b.HasIndex(x => new { x.TenantId, x.Code }).IsUnique();

                b.ApplyObjectExtensionMappings();
            }
        );
    }

    public static void ConfigureParkingQuery(
        this ModelBuilder builder
    )
    {
        Check.NotNull(builder, nameof(builder));

        builder.Entity<InParkVehicleCounterModel>(
            b =>
            {
                b.ToTable(Bitbone3dConsts.ParkingDbTablePrefix + "Q_InParkVehicleCounters", Bitbone3dConsts.DbSchema);

                b.ConfigureByConvention();
                b.Property(x => x.Count).IsRequired();

                b.HasIndex(x => x.TenantId).IsUnique();

                b.ApplyObjectExtensionMappings();
            }
        );

        builder.Entity<ParkingIncomDailyModel>(
            b =>
            {
                b.ToTable(Bitbone3dConsts.ParkingDbTablePrefix + "Q_ParkingIncomDailies", Bitbone3dConsts.DbSchema);

                b.ConfigureByConvention();
                b.Property(x => x.Date).IsRequired();
                b.Property(x => x.TotalAmount).HasPrecision(20, 6).IsRequired();

                b.HasIndex(x => new { x.TenantId, x.Date }).IsUnique();

                b.ApplyObjectExtensionMappings();
            }
        );

        builder.Entity<ParkingRecordModel>(
            b =>
            {
                b.ToTable(Bitbone3dConsts.ParkingDbTablePrefix + "Q_ParkingRecords", Bitbone3dConsts.DbSchema);

                b.ConfigureByConvention();
                b.Property(x => x.LicensePlateNo).HasMaxLength(ParkingConsts.MaxLicensePlateNoLength).IsRequired();
                b.Property(x => x.EntryLane).HasMaxLength(ParkingConsts.MaxEntryLaneLength).IsRequired();
                b.Property(x => x.EntryTime).IsRequired();
                b.Property(x => x.LastParkingSpaceCode).HasMaxLength(ParkingConsts.MaxParkingSpaceCodeLength);
                b.Property(x => x.Exited).IsRequired();
                b.Property(x => x.LastPayTime);
                b.Property(x => x.TotalPaidAmount).IsRequired();
                b.Property(x => x.ExitLane).HasMaxLength(ParkingConsts.MaxEntryLaneLength);
                b.Property(x => x.ExitTime);

                b.HasIndex(x => new { x.TenantId, x.LicensePlateNo, x.EntryTime });
                b.HasIndex(x => new { x.TenantId, x.EntryTime });

                b.ApplyObjectExtensionMappings();
            }
        );

        builder.Entity<ParkingSpaceMonitorModel>(
            b =>
            {
                b.ToTable(Bitbone3dConsts.ParkingDbTablePrefix + "Q_ParkingSpaceMonitors", Bitbone3dConsts.DbSchema);

                b.ConfigureByConvention();
                b.Property(x => x.ParkingSpaceCode).HasMaxLength(ParkingConsts.MaxParkingSpaceCodeLength).IsRequired();
                b.Property(x => x.Location).HasMaxLength(ParkingConsts.MaxParkingSpaceLocationLength);
                b.Property(x => x.Description).HasMaxLength(ParkingConsts.MaxParkingSpaceDescriptionLength);
                b.Property(x => x.IsAvailable).IsRequired();
                b.Property(x => x.ParkingLicensePlateNo).HasMaxLength(ParkingConsts.MaxLicensePlateNoLength);
                b.Property(x => x.ParkedAt);

                b.HasIndex(x => new { x.TenantId, x.ParkingSpaceCode }).IsUnique();
                b.HasIndex(x => new { x.TenantId, x.ParkingLicensePlateNo });

                b.ApplyObjectExtensionMappings();
            }
        );
    }
}