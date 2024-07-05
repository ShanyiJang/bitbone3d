using System;
using System.Threading;
using System.Threading.Tasks;
using Bitbone3d.DddParking.Repositories;
using Bitbone3d.DddParking.ViewModels;
using Bitbone3d.EntityFrameworkCore;
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
}