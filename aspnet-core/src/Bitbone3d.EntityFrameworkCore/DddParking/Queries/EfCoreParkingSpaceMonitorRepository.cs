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

public class EfCoreParkingSpaceMonitorRepository(IDbContextProvider<Bitbone3dDbContext> dbContextProvider)
    : EfCoreRepository<Bitbone3dDbContext, ParkingSpaceMonitorModel, Guid>(dbContextProvider),
        IParkingSpaceMonitorRepository
{
    public Task<ParkingSpaceMonitorModel> GetAsync(string parkingSpaceCode, CancellationToken cancellationToken = default)
    {
        return GetAsync(e => e.ParkingSpaceCode == parkingSpaceCode, true, cancellationToken);
    }

    public Task<ParkingSpaceMonitorModel?> FindAsync(string licensePlateNo, CancellationToken cancellationToken = default)
    {
        return FindAsync(e => e.ParkingLicensePlateNo == licensePlateNo, cancellationToken: cancellationToken);
    }

    public async Task<List<ParkingSpaceMonitorModel>> GetListAsync(
        bool? isAvailable = null,
        string? sorting = null,
        CancellationToken cancellationToken = default
    )
    {
        return await (await GetQueryableAsync())
            .WhereIf(isAvailable.HasValue, e => e.IsAvailable == isAvailable)
            .OrderBy(sorting ?? $"{nameof(ParkingSpaceMonitorModel.ParkingSpaceCode)} ASC")
            .ToListAsync(cancellationToken);
    }
}