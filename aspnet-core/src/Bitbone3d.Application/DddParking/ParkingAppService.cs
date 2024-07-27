using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bitbone3d.DddParking.Commands;
using Bitbone3d.DddParking.Dtos;
using Bitbone3d.DddParking.Repositories;
using Bitbone3d.DddParking.ViewModels;
using Volo.Abp.Application.Dtos;

namespace Bitbone3d.DddParking;

/// <summary>
/// 停车
/// </summary>
public class ParkingAppService(
    PayParkingFeeCommandHandler payParkingFeeCommandHandler,
    ExitVehicleCommandHandler exitVehicleCommandHandler,
    EnterVehicleCommandHandler enterVehicleCommandHandler,
    IParkingRecordRepository parkingRecordRepository,
    IParkingIncomDailyRepository parkingIncomDailyRepository,
    IParkingSpaceMonitorRepository parkingSpaceMonitorRepository,
    IInParkVehicleCounterRepository inParkVehicleCounterRepository
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

    /// <summary>
    /// 查询在场车辆数量
    /// </summary>
    /// <returns></returns>
    public async Task<int> GetInParkingCountAsync()
    {
        return (await inParkVehicleCounterRepository.FindAsync())?.Count ?? 0;
    }

    /// <summary>
    /// 查询车辆位置
    /// </summary>
    /// <param name="licensePlateNo">车牌号</param>
    /// <returns></returns>
    public async Task<ParkingVehiclePositionDto> GetVehiclePositionAsync(string licensePlateNo)
    {
        var parkingSpaceMonitor = await parkingSpaceMonitorRepository.FindAsync(licensePlateNo);
        if (parkingSpaceMonitor == null)
        {
            return new ParkingVehiclePositionDto();
        }

        return new ParkingVehiclePositionDto
        {
            IsVehiclePresent = true,
            ParkingSpaceCode = parkingSpaceMonitor.ParkingSpaceCode,
            Location = parkingSpaceMonitor.Location,
            Description = parkingSpaceMonitor.Description
        };
    }

    /// <summary>
    /// 获取今日收入（截止当前时间）
    /// </summary>
    /// <returns></returns>
    public async Task<decimal> GetTodayIncomeAsync()
    {
        var today = await parkingIncomDailyRepository.FindAsync(Clock.Now.Date);

        return today?.TotalAmount ?? 0;
    }

    /// <summary>
    /// 获取收入列表
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <returns></returns>
    public async Task<ListResultDto<ParkingDailyIncomeDto>> GetDailyIncomeListAsync(
        GetParkingDailyIncomeListInputDto input
    )
    {
        var incomes = await parkingIncomDailyRepository.GetListAsync(input.StartDate, input.EndDate);

        var results = new List<ParkingDailyIncomeDto>();

        var dateIndex = input.StartDate.Date;
        while (dateIndex <= input.EndDate.Date)
        {
            var income = incomes.FirstOrDefault(e => e.Date == dateIndex);

            results.Add(
                new ParkingDailyIncomeDto
                {
                    Date = dateIndex,
                    Amount = income?.TotalAmount ?? 0
                }
            );

            dateIndex = dateIndex.AddDays(1);
        }

        return new ListResultDto<ParkingDailyIncomeDto>(results);
    }

    /// <summary>
    /// 获取车辆进出记录
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <returns></returns>
    public async Task<PagedResultDto<ParkingRecordDto>> GetParkingRecordsAsync(GetParkingRecordPagedInputDto input)
    {
        var totalCount = await parkingRecordRepository.GetCountAsync(
            licensePlateNo: input.LicensePlateNo,
            entryLane: input.EntryLane,
            exitLane: input.ExitLane,
            startEntryTime: input.StartEntryTime,
            endEntryTime: input.EndEntryTime,
            startExitTime: input.StartExitTime,
            endExitTime: input.EndExitTime
        );

        if (totalCount == 0)
        {
            return new PagedResultDto<ParkingRecordDto>();
        }

        var records = await parkingRecordRepository.GetListAsync(
            licensePlateNo: input.LicensePlateNo,
            entryLane: input.EntryLane,
            exitLane: input.ExitLane,
            startEntryTime: input.StartEntryTime,
            endEntryTime: input.EndEntryTime,
            startExitTime: input.StartExitTime,
            endExitTime: input.EndExitTime,
            skipCount: input.SkipCount,
            maxResultCount: input.MaxResultCount,
            sorting: input.Sorting
        );

        return new PagedResultDto<ParkingRecordDto>(
            totalCount,
            ObjectMapper.Map<List<ParkingRecordModel>, List<ParkingRecordDto>>(records)
        );
    }
}