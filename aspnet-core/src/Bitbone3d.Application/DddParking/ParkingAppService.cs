using System.Threading.Tasks;
using Bitbone3d.DddParking.Commands;
using Bitbone3d.DddParking.Dtos;

namespace Bitbone3d.DddParking;

/// <summary>
/// 停车
/// </summary>
public class ParkingAppService(
    PayParkingFeeCommandHandler payParkingFeeCommandHandler,
    ExitVehicleCommandHandler exitVehicleCommandHandler,
    EnterVehicleCommandHandler enterVehicleCommandHandler
) : Bitbone3dAppService, IParkingAppService
{
    public Task EnterAsync(ParkingEnterInputDto input)
    {
        return enterVehicleCommandHandler.HandleAsync(
            new EnterVehicleCommand
            {
                LicensePlateNo = input.LicensePlateNo,
                EntryLane = input.EntryLane,
                OperationTime = Clock.Now
            }
        );
    }

    public Task PayAsync(ParkingPayInputDto input)
    {
        return payParkingFeeCommandHandler.HandleAsync(
            new PayParkingFeeCommand
            {
                LicensePlateNo = input.LicensePlateNo,
                Amount = input.Amount,
                OperationTime = Clock.Now
            }
        );
    }

    public Task ExitAsync(ParkingExitInputDto input)
    {
        return exitVehicleCommandHandler.HandleAsync(
            new ExitVehicleCommand
            {
                LicensePlateNo = input.LicensePlateNo,
                EntryLane = input.EntryLane,
                OperationTime = Clock.Now
            }
        );
    }
}