using System;
using System.Threading.Tasks;
using Bitbone3d.Command;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Bitbone3d.DddParking.Commands;

public class PayParkingFeeCommand : IDomainCommand
{
    public string LicensePlateNo { get; set; } = default!;

    public decimal Amount { get; set; }

    public DateTime OperationTime { get; set; }
}

public class PayParkingFeeCommandHandler(IParkingRepository parkingRepository) : DomainService, ICommandHandler<PayParkingFeeCommand>
{
    /// <summary>
    /// Handler handles the event by implementing this method.
    /// </summary>
    /// <param name="command">Event data</param>
    public async Task HandleAsync(PayParkingFeeCommand command)
    {
        var parking = await parkingRepository.FindAsync(command.LicensePlateNo);
        if (parking == null)
        {
            throw new BusinessException(
                    Bitbone3dDomainErrorCodes.DddParking.VehicleNotEntered,
                    $"车辆 {command.LicensePlateNo} 未入场。"
                )
                .WithData("0", command.LicensePlateNo);
        }

        parking.Pay(command.Amount, command.OperationTime);

        await parkingRepository.UpdateAsync(parking);
    }
}