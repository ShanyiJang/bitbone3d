using System.Threading.Tasks;
using Bitbone3d.DddParking.Commands;
using Bitbone3d.DddParking.Dtos;

namespace Bitbone3d.DddParking;

/// <summary>
/// 车位
/// </summary>
public class ParkingSpaceAppService(
    ParkInManager parkVehicleCommandHandler,
    UnparkVehicleCommandHandler unparkVehicleCommandHandler,
    CreateParkingSpaceCommandHandler createParkingSpaceCommandHandler
) : Bitbone3dAppService, IParkingSpaceAppService
{
    /// <summary>
    /// 创建
    /// </summary>
    /// <param name="input">创建信息</param>
    /// <returns></returns>
    public Task CreateAsync(ParkingSpaceCreateInputDto input)
    {
        return createParkingSpaceCommandHandler.HandleAsync(
            new CreateParkingSpaceCommand
            {
                ParkingSpaceCode = input.ParkingSpaceCode,
                Location = input.Location,
                Description = input.Description,
                OperationTime = Clock.Now
            }
        );
    }

    /// <summary>
    /// 车辆泊入
    /// </summary>
    /// <param name="input">泊入信息</param>
    /// <returns></returns>
    public Task ParkInAsync(ParkingSpaceParkInInputDto input)
    {
        return parkVehicleCommandHandler.ParkInAsync(
            new ParkInInfo
            {
                ParkingSpaceCode = input.ParkingSpaceCode,
                LicensePlateNo = input.LicensePlateNo,
                ParkInTime = Clock.Now
            }
        );
    }

    /// <summary>
    /// 车辆驶离
    /// </summary>
    /// <param name="input">驶离信息</param>
    /// <returns></returns>
    public Task UnParkAsync(ParkingSpaceUnparkInputDto input)
    {
        return unparkVehicleCommandHandler.HandleAsync(
            new UnparkVehicleCommand
            {
                ParkingSpaceCode = input.ParkingSpaceCode,
                OperationTime = Clock.Now
            }
        );
    }
}