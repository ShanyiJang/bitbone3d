using System.Threading.Tasks;

namespace Bitbone3d.DddParking.Services.Alarm;

public interface IParkingAlarmService
{
    Task AlarmAsync(AlarmNotificationInfo notificationInfo);
}