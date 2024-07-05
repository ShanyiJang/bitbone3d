using System.Threading.Tasks;
using Bitbone3d.DddParking.Dtos;
using Volo.Abp.Application.Services;

namespace Bitbone3d.DddParking;

/// <summary>
/// 车位管理
/// </summary>
public interface IParkingSpaceAppService : IApplicationService
{
    /// <summary>
    /// 创建
    /// </summary>
    /// <param name="input">创建信息</param>
    /// <returns></returns>
    Task CreateAsync(ParkingSpaceCreateInputDto input);

    /// <summary>
    /// 车辆泊入
    /// </summary>
    /// <param name="input">泊入信息</param>
    /// <returns></returns>
    Task ParkInAsync(ParkingSpaceParkInInputDto input);

    /// <summary>
    /// 车辆驶离
    /// </summary>
    /// <param name="input">驶离信息</param>
    /// <returns></returns>
    Task UnParkAsync(ParkingSpaceUnparkInputDto input);
}