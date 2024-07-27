using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Bitbone3d.DddParking.Repositories;
using Bitbone3d.DddParking.ViewModels;
using Bitbone3d.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Bitbone3d.DddParking.Queries;

public class EfCoreParkingRecordRepository(IDbContextProvider<Bitbone3dDbContext> dbContextProvider)
    : EfCoreRepository<Bitbone3dDbContext, ParkingRecordModel, Guid>(dbContextProvider),
        IParkingRecordRepository
{
    public Task<ParkingRecordModel?> FindAsync(
        string licensePlateNo,
        DateTime entryTime,
        CancellationToken cancellationToken = default
    )
    {
        return FindAsync(e => e.LicensePlateNo == licensePlateNo && e.EntryTime == entryTime, true, cancellationToken);
    }

    public async Task<int> GetCountAsync(
        string? licensePlateNo = null,
        string? entryLane = null,
        string? exitLane = null,
        DateTime? startEntryTime = null,
        DateTime? endEntryTime = null,
        DateTime? startExitTime = null,
        DateTime? endExitTime = null,
        CancellationToken cancellationToken = default
    )
    {
        return await (await GetQueryableAsync(
            licensePlateNo: licensePlateNo,
            entryLane: entryLane,
            exitLane: exitLane,
            startEntryTime: startEntryTime,
            endEntryTime: endEntryTime,
            startExitTime: startExitTime,
            endExitTime: endExitTime
        )).CountAsync(cancellationToken);
    }

    public async Task<List<ParkingRecordModel>> GetListAsync(
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
    )
    {
        return await (await GetQueryableAsync(
                licensePlateNo: licensePlateNo,
                entryLane: entryLane,
                exitLane: exitLane,
                startEntryTime: startEntryTime,
                endEntryTime: endEntryTime,
                startExitTime: startExitTime,
                endExitTime: endExitTime
            )).OrderBy(sorting ?? $"{nameof(ParkingRecordModel.EntryTime)} ASC")
            .PageBy(skipCount, maxResultCount)
            .ToListAsync(cancellationToken);
    }

    private async Task<IQueryable<ParkingRecordModel>> GetQueryableAsync(
        string? licensePlateNo = null,
        string? entryLane = null,
        string? exitLane = null,
        DateTime? startEntryTime = null,
        DateTime? endEntryTime = null,
        DateTime? startExitTime = null,
        DateTime? endExitTime = null
    )
    {
        return (await base.GetQueryableAsync())
            .WhereIf(!licensePlateNo.IsNullOrWhiteSpace(), e => e.LicensePlateNo == licensePlateNo)
            .WhereIf(!entryLane.IsNullOrWhiteSpace(), e => e.EntryLane == entryLane)
            .WhereIf(!exitLane.IsNullOrWhiteSpace(), e => e.ExitLane == exitLane)
            .WhereIf(startEntryTime.HasValue, e => e.EntryTime >= startEntryTime)
            .WhereIf(endEntryTime.HasValue, e => e.EntryTime <= endEntryTime)
            .WhereIf(startExitTime.HasValue, e => e.ExitTime >= startExitTime)
            .WhereIf(endExitTime.HasValue, e => e.ExitTime <= endExitTime);
    }
}