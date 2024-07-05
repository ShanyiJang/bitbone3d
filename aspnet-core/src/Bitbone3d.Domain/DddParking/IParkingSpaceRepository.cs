using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Bitbone3d.DddParking;

public interface IParkingSpaceRepository : IRepository<ParkingSpace, Guid>
{
    Task<ParkingSpace> GetAsync(string code, CancellationToken cancellationToken = default);

    Task<bool> CheckExistAsync(string code, CancellationToken cancellationToken = default);
}