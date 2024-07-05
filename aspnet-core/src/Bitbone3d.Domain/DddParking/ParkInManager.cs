using System.Threading.Tasks;
using Bitbone3d.DddParking.Commands;
using Volo.Abp.Domain.Services;
using Volo.Abp.EventBus.Local;

namespace Bitbone3d.DddParking;

public class ParkInManager(
    IParkingRepository parkingRepository,
    ILocalEventBus localEventBus,
    ParkVehicleCommandHandler parkVehicleCommandHandler
) : DomainService
{
    public async Task ParkInAsync(ParkInInfo parkInInfo)
    {
        var parking = await parkingRepository.FindAsync(parkInInfo.LicensePlateNo);
        if (parking == null)
        {
            await localEventBus.PublishAsync(
                new VehicleParkFailedEvent
                {
                    ParkingSpaceCode = parkInInfo.ParkingSpaceCode,
                    LicensePlateNo = parkInInfo.LicensePlateNo,
                    HappenTime = parkInInfo.ParkInTime,
                    TenantId = CurrentTenant.Id
                }
            );

            return;
        }

        await parkVehicleCommandHandler.HandleAsync(
            new ParkVehicleCommand
            {
                ParkingSpaceCode = parkInInfo.ParkingSpaceCode,
                LicensePlateNo = parkInInfo.LicensePlateNo,
                EntryTime = parking.EntryTime,
                OperationTime = parkInInfo.ParkInTime
            }
        );
    }
}