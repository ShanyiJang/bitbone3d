using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Bitbone3d.DddParking;

public interface IParkingRepository : IRepository<Parking, Guid>
{
    Task<decimal> GetPaidAmountAsync(string lcensePlateNo, CancellationToken cancellationToken = default);
    Task<Parking?> FindAsync(string lcensePlateNo, CancellationToken cancellationToken = default);
    Task<bool> CheckExistAsync(string lcensePlateNo, CancellationToken cancellationToken = default);
}