using System;
using System.Threading;
using System.Threading.Tasks;
using Bitbone3d.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Bitbone3d.DddParking;

public class EfCoreParkingSpaceRepository(IDbContextProvider<Bitbone3dDbContext> dbContextProvider)
    : EfCoreRepository<Bitbone3dDbContext, ParkingSpace, Guid>(dbContextProvider), IParkingSpaceRepository
{
    public Task<ParkingSpace> GetAsync(string code, CancellationToken cancellationToken = default)
    {
        return GetAsync(e => e.Code == code, true, cancellationToken);
    }

    public async Task<bool> CheckExistAsync(string code, CancellationToken cancellationToken = default)
    {
        return await (await GetQueryableAsync()).AnyAsync(e => e.Code == code, cancellationToken);
    }
}