using System.Threading.Tasks;
using Bitbone3d.DddParking.Repositories;
using Bitbone3d.DddParking.ViewModels;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;

namespace Bitbone3d.DddParking.Materializers;

public class ParkingIncomDailyMaterializer(
    ICurrentTenant currentTenant,
    IGuidGenerator guidGenerator,
    IParkingIncomDailyRepository parkingIncomDailyRepository
) : ILocalEventHandler<VehicleExitedEvent>, ITransientDependency
{
    /// <summary>
    /// Handler handles the event by implementing this method.
    /// </summary>
    /// <param name="eventData">Event data</param>
    public async Task HandleEventAsync(VehicleExitedEvent eventData)
    {
        using (currentTenant.Change(eventData.TenantId))
        {
            var isNewCreate = false;
            var incomeDaily = await parkingIncomDailyRepository.FindAsync(eventData.HappenTime.Date);
            if (incomeDaily == null)
            {
                incomeDaily = new ParkingIncomDailyModel(
                    guidGenerator.Create(),
                    eventData.HappenTime.Date,
                    eventData.TenantId
                );

                isNewCreate = true;
            }

            incomeDaily.Add(eventData.TotalPayAmount);

            if (isNewCreate)
            {
                await parkingIncomDailyRepository.InsertAsync(incomeDaily);
                return;
            }

            await parkingIncomDailyRepository.UpdateAsync(incomeDaily);
        }
    }
}