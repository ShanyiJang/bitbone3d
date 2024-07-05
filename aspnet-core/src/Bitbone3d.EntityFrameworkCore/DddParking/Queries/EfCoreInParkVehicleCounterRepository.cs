using System;
using System.Threading;
using System.Threading.Tasks;
using Bitbone3d.DddParking.Repositories;
using Bitbone3d.DddParking.ViewModels;
using Bitbone3d.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Bitbone3d.DddParking.Queries;

public class EfCoreInParkVehicleCounterRepository(IDbContextProvider<Bitbone3dDbContext> dbContextProvider)
    : EfCoreRepository<Bitbone3dDbContext, InParkVehicleCounterModel, Guid>(dbContextProvider),
        IInParkVehicleCounterRepository
{
    public async Task<InParkVehicleCounterModel?> FindAsync(CancellationToken cancellationToken = default)
    {
        return await (await GetDbSetAsync()).SingleOrDefaultAsync(cancellationToken);
    }
}