using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bitbone3d.DddParking.Repositories;
using Bitbone3d.DddParking.ViewModels;
using Bitbone3d.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Bitbone3d.DddParking.Queries;

public class EfCoreParkingIncomDailyRepository(IDbContextProvider<Bitbone3dDbContext> dbContextProvider)
    : EfCoreRepository<Bitbone3dDbContext, ParkingIncomDailyModel, Guid>(dbContextProvider),
        IParkingIncomDailyRepository
{
    public Task<ParkingIncomDailyModel?> FindAsync(DateTime date, CancellationToken cancellationToken = default)
    {
        return FindAsync(e => e.Date.Date == date.Date, true, cancellationToken);
    }

    public async Task<List<ParkingIncomDailyModel>> GetListAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default)
    {
        return await (await GetQueryableAsync())
            .Where(e => e.Date >= startDate.Date)
            .Where(e => e.Date <= endDate.Date)
            .OrderBy(e => e.Date)
            .ToListAsync(cancellationToken);
    }
}