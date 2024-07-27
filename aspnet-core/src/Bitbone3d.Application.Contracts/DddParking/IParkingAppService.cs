using System.Threading.Tasks;
using Bitbone3d.DddParking.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Bitbone3d.DddParking;

/// <summary>
/// 泊车管理
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
    
    /// <summary>
    /// 查询在场车辆数量
    /// </summary>
    /// <returns></returns>
    Task<int> GetInParkingCountAsync();

    /// <summary>
    /// 查询车辆位置
    /// </summary>
    /// <param name="licensePlateNo">车牌号</param>
    /// <returns></returns>
    Task<ParkingVehiclePositionDto> GetVehiclePositionAsync(string licensePlateNo);
    
    /// <summary>
    /// 获取今日收入（截止当前时间）
    /// </summary>
    /// <returns></returns>
    Task<decimal> GetTodayIncomeAsync();

    /// <summary>
    /// 获取收入列表
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <returns></returns>
    Task<ListResultDto<ParkingDailyIncomeDto>> GetDailyIncomeListAsync(GetParkingDailyIncomeListInputDto input);
    
    /// <summary>
    /// 获取车辆进出记录
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <returns></returns>
    Task<PagedResultDto<ParkingRecordDto>> GetParkingRecordsAsync(GetParkingRecordPagedInputDto input);
}