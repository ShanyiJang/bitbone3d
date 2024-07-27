using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Bitbone3d.DddParking.ViewModels;
using Volo.Abp.Domain.Repositories;

namespace Bitbone3d.DddParking.Repositories;

public interface IParkingSpaceMonitorRepository : IRepository
{
    Task<ParkingSpaceMonitorModel> GetAsync(string parkingSpaceCode, CancellationToken cancellationToken = default);

    Task<ParkingSpaceMonitorModel?> FindAsync(string licensePlateNo, CancellationToken cancellationToken = default);

    Task<List<ParkingSpaceMonitorModel>> GetListAsync(
        bool? isAvailable = null,
        string? sorting = null,
        CancellationToken cancellationToken = default
    );

    Task<ParkingSpaceMonitorModel> InsertAsync(
        ParkingSpaceMonitorModel model,
        bool autoSave = false,
        CancellationToken cancellationToken = default
    );

    Task<ParkingSpaceMonitorModel> UpdateAsync(
        ParkingSpaceMonitorModel model,
        bool autoSave = false,
        CancellationToken cancellationToken = default
    );
}