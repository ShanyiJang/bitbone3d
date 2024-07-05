using System.Threading.Tasks;
using Bitbone3d.DddParking.Repositories;
using Bitbone3d.DddParking.ViewModels;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;

namespace Bitbone3d.DddParking.Materializers;

public class ParkingRecordMaterializer(
    ICurrentTenant currentTenant,
    IGuidGenerator guidGenerator,
    IParkingRecordRepository parkingRecordRepository
) : ILocalEventHandler<VehicleEnteredEvent>,
    ILocalEventHandler<VehicleParkedEvent>,
    ILocalEventHandler<ParkingFeePaidEvent>,
    ILocalEventHandler<VehicleExitedEvent>, ITransientDependency
{
    /// <summary>
    /// Handler handles the event by implementing this method.
    /// </summary>
    /// <param name="eventData">Event data</param>
    public Task HandleEventAsync(VehicleEnteredEvent eventData)
    {
        using (currentTenant.Change(eventData.TenantId))
        {
            var parkingRecord = new ParkingRecordModel(
                guidGenerator.Create(),
                eventData.LicensePlateNo,
                eventData.EntryLane,
                eventData.HappenTime,
                eventData.TenantId
            );

            return parkingRecordRepository.InsertAsync(parkingRecord);
        }
    }

    /// <summary>
    /// Handler handles the event by implementing this method.
    /// </summary>
    /// <param name="eventData">Event data</param>
    public async Task HandleEventAsync(VehicleParkedEvent eventData)
    {
        using (currentTenant.Change(eventData.TenantId))
        {
            var parkingRecord = await parkingRecordRepository.FindAsync(eventData.LicensePlateNo, eventData.EntryTime);
            if (parkingRecord == null)
            {
                throw new UserFriendlyException($"未找到车辆 {eventData.LicensePlateNo} 在 {eventData.EntryTime} 入场的的停车记录。");
            }

            parkingRecord.Park(eventData.ParkingSpaceCode);

            await parkingRecordRepository.UpdateAsync(parkingRecord);
        }
    }

    /// <summary>
    /// Handler handles the event by implementing this method.
    /// </summary>
    /// <param name="eventData">Event data</param>
    public async Task HandleEventAsync(ParkingFeePaidEvent eventData)
    {
        using (currentTenant.Change(eventData.TenantId))
        {
            var parkingRecord = await parkingRecordRepository.FindAsync(eventData.LicensePlateNo, eventData.EntryTime);
            if (parkingRecord == null)
            {
                throw new UserFriendlyException($"未找到车辆 {eventData.LicensePlateNo} 在 {eventData.EntryTime} 入场的的停车记录。");
            }

            parkingRecord.Pay(eventData.PayAmount, eventData.HappenTime);

            await parkingRecordRepository.UpdateAsync(parkingRecord);
        }
    }

    /// <summary>
    /// Handler handles the event by implementing this method.
    /// </summary>
    /// <param name="eventData">Event data</param>
    public async Task HandleEventAsync(VehicleExitedEvent eventData)
    {
        using (currentTenant.Change(eventData.TenantId))
        {
            var parkingRecord = await parkingRecordRepository.FindAsync(eventData.LicensePlateNo, eventData.EntryTime);
            if (parkingRecord == null)
            {
                throw new UserFriendlyException($"未找到车辆 {eventData.LicensePlateNo} 在 {eventData.EntryTime} 入场的的停车记录。");
            }

            parkingRecord.Exit(eventData.EntryLane, eventData.HappenTime);

            await parkingRecordRepository.UpdateAsync(parkingRecord);
        }
    }
}