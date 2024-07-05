using System.Threading;
using System.Threading.Tasks;
using Bitbone3d.DddParking.ViewModels;
using Volo.Abp.Domain.Repositories;

namespace Bitbone3d.DddParking.Repositories;

public interface IInParkVehicleCounterRepository : IRepository
{
    Task<InParkVehicleCounterModel?> FindAsync(CancellationToken cancellationToken = default);

    Task<InParkVehicleCounterModel> InsertAsync(
        InParkVehicleCounterModel model,
        bool autoSave = false,
        CancellationToken cancellationToken = default
    );

    Task<InParkVehicleCounterModel> UpdateAsync(
        InParkVehicleCounterModel model,
        bool autoSave = false,
        CancellationToken cancellationToken = default
    );
}