using System;
using System.Threading;
using System.Threading.Tasks;
using Bitbone3d.DddParking.ViewModels;
using Volo.Abp.Domain.Repositories;

namespace Bitbone3d.DddParking.Repositories;

public interface IParkingRecordRepository : IRepository
{
    Task<ParkingRecordModel?> FindAsync(
        string licensePlateNo,
        DateTime entryTime,
        CancellationToken cancellationToken = default
    );

    Task<ParkingRecordModel> InsertAsync(
        ParkingRecordModel model,
        bool autoSave = false,
        CancellationToken cancellationToken = default
    );

    Task<ParkingRecordModel> UpdateAsync(
        ParkingRecordModel model,
        bool autoSave = false,
        CancellationToken cancellationToken = default
    );
}