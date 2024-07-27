using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Bitbone3d.DddParking.ViewModels;
using Volo.Abp.Domain.Repositories;

namespace Bitbone3d.DddParking.Repositories;

public interface IParkingIncomDailyRepository : IRepository
{
    Task<ParkingIncomDailyModel?> FindAsync(DateTime date, CancellationToken cancellationToken = default);

    Task<List<ParkingIncomDailyModel>> GetListAsync(
        DateTime startDate,
        DateTime endDate,
        CancellationToken cancellationToken = default
    );

    Task<ParkingIncomDailyModel> InsertAsync(
        ParkingIncomDailyModel model,
        bool autoSave = false,
        CancellationToken cancellationToken = default
    );

    Task<ParkingIncomDailyModel> UpdateAsync(
        ParkingIncomDailyModel model,
        bool autoSave = false,
        CancellationToken cancellationToken = default
    );
}