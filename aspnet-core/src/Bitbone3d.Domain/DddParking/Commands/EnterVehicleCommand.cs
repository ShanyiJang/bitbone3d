using System;
using System.Threading.Tasks;
using Bitbone3d.Command;
using Volo.Abp.Domain.Services;
using Volo.Abp.EventBus.Local;

namespace Bitbone3d.DddParking.Commands;

public class EnterVehicleCommand : IDomainCommand
{
    public string LicensePlateNo { get; set; } = default!;
    public string EntryLane { get; set; } = default!;
    public DateTime OperationTime { get; set; }
}

public class EnterVehicleCommandHandler(
    ILocalEventBus localEventBus,
    IParkingRepository parkingRepository
) : DomainService, ICommandHandler<EnterVehicleCommand>
{
    /// <summary>
    /// Handler handles the event by implementing this method.
    /// </summary>
    /// <param name="command">Event data</param>
    public async Task HandleAsync(EnterVehicleCommand command)
    {
        if (await parkingRepository.CheckExistAsync(command.LicensePlateNo))
        {
            await localEventBus.PublishAsync(
                new VehicleEnterFailedEvent
                {
                    LicensePlateNo = command.LicensePlateNo,
                    EntryLane = command.EntryLane,
                    EntryTime = command.OperationTime,
                    HappenTime = command.OperationTime,
                    TenantId = CurrentTenant.Id
                }
            );

            return;
        }

        await parkingRepository.InsertAsync(
            new Parking(
                GuidGenerator.Create(),
                command.LicensePlateNo,
                command.EntryLane,
                command.OperationTime,
                CurrentTenant.Id
            )
        );
    }
}