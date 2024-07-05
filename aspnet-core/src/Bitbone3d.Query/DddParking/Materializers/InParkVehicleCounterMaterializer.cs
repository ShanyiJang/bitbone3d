using System.Threading.Tasks;
using Bitbone3d.DddParking.Repositories;
using Bitbone3d.DddParking.ViewModels;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;

namespace Bitbone3d.DddParking.Materializers;

public class InParkVehicleCounterMaterializer(
    ICurrentTenant currentTenant,
    IGuidGenerator guidGenerator,
    IInParkVehicleCounterRepository inParkVehicleCounterRepository
)
    : ILocalEventHandler<VehicleEnteredEvent>, ITransientDependency
{
    /// <summary>
    /// Handler handles the event by implementing this method.
    /// </summary>
    /// <param name="eventData">Event data</param>
    public async Task HandleEventAsync(VehicleEnteredEvent eventData)
    {
        using (currentTenant.Change(eventData.TenantId))
        {
            var isNewCreate = false;
            var counter = await inParkVehicleCounterRepository.FindAsync();
            if (counter == null)
            {
                counter = new InParkVehicleCounterModel(
                    guidGenerator.Create(),
                    currentTenant.Id
                );
                isNewCreate = true;
            }

            counter.Enter();

            if (isNewCreate)
            {
                await inParkVehicleCounterRepository.InsertAsync(counter);
                return;
            }

            await inParkVehicleCounterRepository.UpdateAsync(counter);
        }
    }
}