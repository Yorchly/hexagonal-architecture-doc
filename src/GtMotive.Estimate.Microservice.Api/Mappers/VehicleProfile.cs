using AutoMapper;
using GtMotive.Estimate.Microservice.Api.Requests;
using GtMotive.Estimate.Microservice.Api.ViewModels;
using GtMotive.Estimate.Microservice.ApplicationCore.Inputs;
using GtMotive.Estimate.Microservice.ApplicationCore.Inputs.ValueObjects.Vehicle;
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
            CreateMap<CreateVehicleRequest, VehicleInput>()
                .ForMember(
                    vehicleInput => vehicleInput.CreatedAt,
                    config => config.MapFrom(
                        request => new CreatedAt(request.CreatedAt)))
                .ReverseMap()
                .ForMember(
                    request => request.CreatedAt,
                    config => config.MapFrom(
                        vehicleInput => vehicleInput.CreatedAt.ToDateTime()));
            CreateMap<Vehicle, VehicleInput>()
                .ForMember(
                    vehicleInput => vehicleInput.CreatedAt,
                    config => config.MapFrom(
                        vehicle => new CreatedAt(vehicle.CreatedAt)))
                .ReverseMap()
                .ForMember(
                    vehicle => vehicle.CreatedAt,
                    config => config.MapFrom(
                        vehicleInput => vehicleInput.CreatedAt.ToDateTime()));
            CreateMap<RentVehicleRequest, RentVehicleInput>()
                .ReverseMap();
            CreateMap<ReturnVehicleRequest, ReturnVehicleInput>()
                .ReverseMap();
        }
    }
}
