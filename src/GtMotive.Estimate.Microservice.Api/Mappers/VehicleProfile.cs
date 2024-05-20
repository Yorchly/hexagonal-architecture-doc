using AutoMapper;
using GtMotive.Estimate.Microservice.Api.ViewModels;
using GtMotive.Estimate.Microservice.ApplicationCore.Outputs;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Api.Mappers
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<Vehicle, VehicleResponse>()
                .ReverseMap();
            CreateMap<Vehicle, VehicleOutput>()
                .ReverseMap();
            CreateMap<VehicleOutput, VehicleResponse>()
                .ReverseMap();
        }
    }
}
