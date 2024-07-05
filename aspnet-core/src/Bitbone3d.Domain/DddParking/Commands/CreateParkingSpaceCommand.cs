using System;
using System.Threading.Tasks;
using Bitbone3d.Command;
using Volo.Abp;
using Volo.Abp.Domain.Services;
using Volo.Abp.EventBus.Local;

namespace Bitbone3d.DddParking.Commands;

public class CreateParkingSpaceCommand : IDomainCommand
{
    public string ParkingSpaceCode { get; set; } = default!;

    public string? Location { get; set; }

    public string? Description { get; set; }

    public DateTime OperationTime { get; set; }
}

public class CreateParkingSpaceCommandHandler(
    ILocalEventBus localEventBus,
    IParkingSpaceRepository parkingSpaceRepository
) : DomainService, ICommandHandler<CreateParkingSpaceCommand>
{
    public async Task HandleAsync(CreateParkingSpaceCommand command)
    {
        if (await parkingSpaceRepository.CheckExistAsync(command.ParkingSpaceCode))
        {
            throw new UserFriendlyException($"车位号 {command.ParkingSpaceCode} 已被占用，车位创建失败。");
        }

        var parkingSpace = new ParkingSpace(
            GuidGenerator.Create(),
            command.ParkingSpaceCode,
            CurrentTenant.Id
        );

        await parkingSpaceRepository.InsertAsync(parkingSpace);

        await localEventBus.PublishAsync(
            new ParkingSpaceCreatedEvent
            {
                ParkingSpaceCode = parkingSpace.Code,
                Location = command.Location,
                Description = command.Description,
                HappenTime = command.OperationTime,
                TenantId = parkingSpace.TenantId
            }
        );
    }
}