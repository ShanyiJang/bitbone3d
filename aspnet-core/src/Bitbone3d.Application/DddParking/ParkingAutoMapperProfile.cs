using AutoMapper;
using Bitbone3d.DddParking.Dtos;
using Bitbone3d.DddParking.ViewModels;

namespace Bitbone3d.DddParking;

public class ParkingAutoMapperProfile : Profile
{
    public ParkingAutoMapperProfile()
    {
        CreateMap<ParkingSpaceMonitorModel, ParkingSpaceStatusDto>();
        CreateMap<ParkingRecordModel, ParkingRecordDto>();
    }
}