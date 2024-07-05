using System;
using System.Threading.Tasks;
using Bitbone3d.Command;
using Volo.Abp.Domain.Services;

namespace Bitbone3d.DddParking.Commands;

public class UnparkVehicleCommand : IDomainCommand
{
    public string ParkingSpaceCode { get; set; } = default!;

    public DateTime OperationTime { get; set; }
}

public class UnparkVehicleCommandHandler(IParkingSpaceRepository parkingSpaceRepository)
    : DomainService, ICommandHandler<UnparkVehicleCommand>
{
    public async Task HandleAsync(UnparkVehicleCommand command)
    {
        var parkingSpace = await parkingSpaceRepository.GetAsync(command.ParkingSpaceCode);

        parkingSpace.Unpark(command.OperationTime);

        await parkingSpaceRepository.UpdateAsync(parkingSpace);
    }
}