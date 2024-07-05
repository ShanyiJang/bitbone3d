using System.Threading.Tasks;
using Bitbone3d.DddParking.Services.Alarm;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus;

namespace Bitbone3d.DddParking.Policies;

public class ParkingAlarmPolicy(IParkingAlarmService parkingAlarmService) :
    ILocalEventHandler<VehicleExitFailedEvent>,
    ILocalEventHandler<VehicleEnterFailedEvent>,
    ILocalEventHandler<VehicleParkFailedEvent>, ITransientDependency
{
    /// <summary>
    /// Handler handles the event by implementing this method.
    /// </summary>
    /// <param name="eventData">Event data</param>
    public Task HandleEventAsync(VehicleEnterFailedEvent eventData)
    {
        return parkingAlarmService.AlarmAsync(
            new AlarmNotificationInfo
            {
                LicensePlateNumber = eventData.LicensePlateNo,
                AlarmMessage = "车辆已入场，不允许重复入场！"
            }
        );
    }

    /// <summary>
    /// Handler handles the event by implementing this method.
    /// </summary>
    /// <param name="eventData">Event data</param>
    public Task HandleEventAsync(VehicleExitFailedEvent eventData)
    {
        return parkingAlarmService.AlarmAsync(
            new AlarmNotificationInfo
            {
                LicensePlateNumber = eventData.LicensePlateNo,
                AlarmMessage = "车辆未入场，无法出场！"
            }
        );
    }

    /// <summary>
    /// Handler handles the event by implementing this method.
    /// </summary>
    /// <param name="eventData">Event data</param>
    public Task HandleEventAsync(VehicleParkFailedEvent eventData)
    {
        return parkingAlarmService.AlarmAsync(
            new AlarmNotificationInfo
            {
                LicensePlateNumber = eventData.LicensePlateNo,
                AlarmMessage = "车辆未入场，无法泊入车位！"
            }
        );
    }
}