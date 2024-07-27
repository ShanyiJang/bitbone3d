using System.Collections.Generic;
using System.Threading.Tasks;
using Bitbone3d.DddParking.Commands;
using Bitbone3d.DddParking.Dtos;
using Bitbone3d.DddParking.Repositories;
using Bitbone3d.DddParking.ViewModels;
using Volo.Abp.Application.Dtos;

namespace Bitbone3d.DddParking;

/// <summary>
/// 车位
/// </summary>
public class ParkingSpaceAppService(
    ParkInManager parkVehicleCommandHandler,
    UnparkVehicleCommandHandler unparkVehicleCommandHandler,
    IParkingSpaceMonitorRepository parkingSpaceMonitorRepository,
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

    /// <summary>
    /// 获取车位状态
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <returns></returns>
    public async Task<ListResultDto<ParkingSpaceStatusDto>> GetStatusListAsync(GetParkingStatusListInputDto input)
    {
        var parkingSpaces = await parkingSpaceMonitorRepository.GetListAsync(
            input.IsAvailable,
            input.Sorting
        );

        return new ListResultDto<ParkingSpaceStatusDto>(
            ObjectMapper.Map<List<ParkingSpaceMonitorModel>, List<ParkingSpaceStatusDto>>(parkingSpaces)
        );
    }
}