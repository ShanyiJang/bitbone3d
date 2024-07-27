using System;
using System.Collections.Generic;
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

    Task<int> GetCountAsync(
        string? licensePlateNo = null,
        string? entryLane = null,
        string? exitLane = null,
        DateTime? startEntryTime = null,
        DateTime? endEntryTime = null,
        DateTime? startExitTime = null,
        DateTime? endExitTime = null,
        CancellationToken cancellationToken = default
    );

    Task<List<ParkingRecordModel>> GetListAsync(
        string? licensePlateNo = null,
        string? entryLane = null,
        string? exitLane = null,
        DateTime? startEntryTime = null,
        DateTime? endEntryTime = null,
        DateTime? startExitTime = null,
        DateTime? endExitTime = null,
        int skipCount = 0,
        int maxResultCount = int.MaxValue,
        string? sorting = null,
        CancellationToken cancellationToken = default
    );
}