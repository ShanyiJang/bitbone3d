using System;
using System.Threading.Tasks;
using Bitbone3d.Command;
using Volo.Abp.Domain.Services;

namespace Bitbone3d.DddParking.Commands;

public class ParkVehicleCommand : IDomainCommand
{
    public string ParkingSpaceCode { get; set; } = default!;

    public string LicensePlateNo { get; set; } = default!;

    public DateTime EntryTime { get; set; }

    public DateTime OperationTime { get; set; }
}

public class ParkVehicleCommandHandler(IParkingSpaceRepository parkingSpaceRepository)
    : DomainService, ICommandHandler<ParkVehicleCommand>
{
    public async Task HandleAsync(ParkVehicleCommand command)
    {
        var parkingSpace = await parkingSpaceRepository.GetAsync(command.ParkingSpaceCode);

        parkingSpace.Park(command.LicensePlateNo, command.EntryTime, command.OperationTime);

        await parkingSpaceRepository.UpdateAsync(parkingSpace);
    }
}