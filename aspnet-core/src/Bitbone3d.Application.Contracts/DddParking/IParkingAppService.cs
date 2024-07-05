using System.Threading.Tasks;
using Bitbone3d.DddParking.Dtos;
using Volo.Abp.Application.Services;

namespace Bitbone3d.DddParking;

/// <summary>
/// 停车
/// </summary>
public interface IParkingAppService : IApplicationService
{
    /// <summary>
    /// 车辆入场
    /// </summary>
    /// <param name="input">入场信息</param>
    /// <returns></returns>
    Task EnterAsync(ParkingEnterInputDto input);
    
    /// <summary>
    /// 费用支付
    /// </summary>
    /// <param name="input">支付信息</param>
    /// <returns></returns>
    Task PayAsync(ParkingPayInputDto input);

    /// <summary>
    /// 车辆出场
    /// </summary>
    /// <param name="input">支付信息</param>
    /// <returns></returns>
    Task ExitAsync(ParkingExitInputDto input);
}