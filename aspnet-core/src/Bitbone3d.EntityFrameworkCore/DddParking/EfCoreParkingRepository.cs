using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bitbone3d.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Bitbone3d.DddParking;

public class EfCoreParkingRepository(IDbContextProvider<Bitbone3dDbContext> dbContextProvider)
    : EfCoreRepository<Bitbone3dDbContext, Parking, Guid>(dbContextProvider), IParkingRepository
{
    public async Task<decimal> GetPaidAmountAsync(string lcensePlateNo, CancellationToken cancellationToken = default)
    {
        return await (await GetDbSetAsync())
            .Where(p => p.LicensePlateNo == lcensePlateNo)
            .Select(e => e.PaidAmount)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public Task<Parking?> FindAsync(string lcensePlateNo, CancellationToken cancellationToken = default)
    {
        return FindAsync(p => p.LicensePlateNo == lcensePlateNo, true, cancellationToken);
    }

    public async Task<bool> CheckExistAsync(string lcensePlateNo, CancellationToken cancellationToken = default)
    {
        return await (await GetDbSetAsync())
            .AnyAsync(p => p.LicensePlateNo == lcensePlateNo, cancellationToken);
    }
}