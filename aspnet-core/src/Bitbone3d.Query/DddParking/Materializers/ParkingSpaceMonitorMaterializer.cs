using System.Threading.Tasks;
using Bitbone3d.DddParking.Repositories;
using Bitbone3d.DddParking.ViewModels;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;

namespace Bitbone3d.DddParking.Materializers;

public class ParkingSpaceMonitorMaterializer(
    ICurrentTenant currentTenant,
    IGuidGenerator guidGenerator,
    IParkingSpaceMonitorRepository parkingSpaceMonitorRepository
) : ILocalEventHandler<VehicleParkedEvent>,
    ILocalEventHandler<VehicleDeparkedEvent>,
    ILocalEventHandler<ParkingSpaceCreatedEvent>, ITransientDependency
{
    /// <summary>
    /// Handler handles the event by implementing this method.
    /// </summary>
    /// <param name="eventData">Event data</param>
    public async Task HandleEventAsync(VehicleParkedEvent eventData)
    {
        using (currentTenant.Change(eventData.TenantId))
        {
            var spaceMonitor = await parkingSpaceMonitorRepository.GetAsync(eventData.ParkingSpaceCode);

            spaceMonitor.Park(eventData.LicensePlateNo, eventData.HappenTime);

            await parkingSpaceMonitorRepository.UpdateAsync(spaceMonitor);
        }
    }

    /// <summary>
    /// Handler handles the event by implementing this method.
    /// </summary>
    /// <param name="eventData">Event data</param>
    public async Task HandleEventAsync(VehicleDeparkedEvent eventData)
    {
        using (currentTenant.Change(eventData.TenantId))
        {
            var spaceMonitor = await parkingSpaceMonitorRepository.GetAsync(eventData.ParkingSpaceCode);

            spaceMonitor.Unpark();

            await parkingSpaceMonitorRepository.UpdateAsync(spaceMonitor);
        }
    }

    /// <summary>
    /// Handler handles the event by implementing this method.
    /// </summary>
    /// <param name="eventData">Event data</param>
    public async Task HandleEventAsync(ParkingSpaceCreatedEvent eventData)
    {
        using (currentTenant.Change(eventData.TenantId))
        {
            var spaceMonitor = new ParkingSpaceMonitorModel(
                id: guidGenerator.Create(),
                parkingSpaceCode: eventData.ParkingSpaceCode,
                location: eventData.Location,
                description: eventData.Description,
                tenantId: eventData.TenantId
            );

            await parkingSpaceMonitorRepository.InsertAsync(spaceMonitor);
        }
    }
}