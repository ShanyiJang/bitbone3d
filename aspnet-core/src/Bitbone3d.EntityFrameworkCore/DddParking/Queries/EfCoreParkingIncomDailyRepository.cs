using System;
using System.Threading;
using System.Threading.Tasks;
using Bitbone3d.DddParking.Repositories;
using Bitbone3d.DddParking.ViewModels;
using Bitbone3d.EntityFrameworkCore;
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
}