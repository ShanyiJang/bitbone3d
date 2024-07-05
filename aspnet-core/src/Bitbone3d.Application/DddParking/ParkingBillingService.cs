using System.Threading.Tasks;
using Bitbone3d.DddParking.Services.Billing;
using Volo.Abp.DependencyInjection;

namespace Bitbone3d.DddParking;

public class ParkingBillingService : IParkingBillingService, ITransientDependency
{
    public Task<decimal> CalculateFeeAsync(FeeCalculationRequest request)
    {
        return Task.FromResult(10m);
    }
}