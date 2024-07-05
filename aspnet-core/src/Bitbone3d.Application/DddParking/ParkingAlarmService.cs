using System.Threading.Tasks;
using Bitbone3d.DddParking.Services.Alarm;
using Microsoft.Extensions.Logging;
using Volo.Abp.DependencyInjection;

namespace Bitbone3d.DddParking;

public class ParkingAlarmService(ILogger<ParkingAlarmService> logger) : IParkingAlarmService, ITransientDependency
{
    public Task AlarmAsync(AlarmNotificationInfo notificationInfo)
    {
        logger.LogWarning("车辆 {0} 出现异常 {1}.", notificationInfo.LicensePlateNumber, notificationInfo.AlarmMessage);

        return Task.CompletedTask;
    }
}