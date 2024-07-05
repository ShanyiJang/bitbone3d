using System;
using System.Threading.Tasks;
using Bitbone3d.Command;
using Bitbone3d.DddParking.Services.Billing;
using Volo.Abp;
using Volo.Abp.Domain.Services;
using Volo.Abp.EventBus.Local;

namespace Bitbone3d.DddParking.Commands;

public class ExitVehicleCommand : IDomainCommand
{
    public string LicensePlateNo { get; set; } = default!;
    public string EntryLane { get; set; } = default!;

    public DateTime OperationTime { get; set; }
}

public class ExitVehicleCommandHandler(
    ILocalEventBus localEventBus,
    IParkingRepository parkingRepository,
    IParkingBillingService parkingBillingService
) : DomainService, ICommandHandler<ExitVehicleCommand>
{
    /// <summary>
    /// Handler handles the event by implementing this method.
    /// </summary>
    /// <param name="command">Event data</param>
    public async Task HandleAsync(ExitVehicleCommand command)
    {
        var parking = await parkingRepository.FindAsync(command.LicensePlateNo);
        if (parking == null)
        {
            await localEventBus.PublishAsync(
                new VehicleExitFailedEvent
                {
                    LicensePlateNo = command.LicensePlateNo,
                    EntryLane = command.EntryLane,
                    HappenTime = command.OperationTime,
                    TenantId = CurrentTenant.Id
                }
            );

            return;
        }

        var canExit = false;
        if (command.OperationTime - parking.EntryTime > TimeSpan.FromMinutes(15))
        {
            canExit = true;
        }
        else
        {
            var amountToPay = await parkingBillingService.CalculateFeeAsync(
                new FeeCalculationRequest
                {
                    EntryTime = default,
                    ExitTime = null
                }
            );

            if (parking.PaidAmount >= amountToPay)
            {
                canExit = true;
            }
        }

        if (!canExit)
        {
            throw new BusinessException(Bitbone3dDomainErrorCodes.DddParking.FeeUnpaid, "停车费用未结清，请结清后重新出场。");
        }
        
        await localEventBus.PublishAsync(
            new VehicleExitedEvent
            {
                LicensePlateNo = command.LicensePlateNo,
                EntryTime = parking.EntryTime,
                EntryLane = command.EntryLane,
                TotalPayAmount = parking.PaidAmount,
                HappenTime = command.OperationTime,
                TenantId = CurrentTenant.Id
            }
        );

        await parkingRepository.DeleteAsync(parking);
    }
}