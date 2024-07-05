using System;
using System.Threading;
using System.Threading.Tasks;
using Bitbone3d.DddParking.Repositories;
using Bitbone3d.DddParking.ViewModels;
using Bitbone3d.EntityFrameworkCore;
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
}