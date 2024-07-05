using System.Threading.Tasks;

namespace Bitbone3d.DddParking.Services.Billing;

public interface IParkingBillingService
{
    Task<decimal> CalculateFeeAsync(FeeCalculationRequest request);
}