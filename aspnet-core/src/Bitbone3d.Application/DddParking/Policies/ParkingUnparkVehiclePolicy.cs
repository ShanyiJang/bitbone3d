using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus;

namespace Bitbone3d.DddParking.Policies;

public class ParkingUnparkVehiclePolicy :
    ILocalEventHandler<VehicleExitedEvent>, ITransientDependency
{
    /// <summary>
    /// Handler handles the event by implementing this method.
    /// </summary>
    /// <param name="eventData">Event data</param>
    public Task HandleEventAsync(VehicleExitedEvent eventData)
    {
        // TODO 当离场车辆依然占用车位时需要驶离车位
        return Task.CompletedTask;
    }
}