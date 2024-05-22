using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.Api.Presenters.Interfaces;
using GtMotive.Estimate.Microservice.ApplicationCore.Outputs;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Infrastructure.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases
{
    internal class GetAllVehiclesUseCase : IGetAllVehiclesUseCase
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IGetAllVehiclePresenter _outputPort;
        private readonly IMapper _mapper;

        public GetAllVehiclesUseCase(
            IVehicleRepository vehicleRepository,
            IGetAllVehiclePresenter outputPort,
            IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _outputPort = outputPort;
            _mapper = mapper;
        }

        public async Task Execute()
        {
            var vehicles = await _vehicleRepository.GetAsync();

            BuildOutput(vehicles);
        }

        private void BuildOutput(List<Vehicle> vehicles)
        {
            var vehicleOutputs =
                _mapper.Map<List<VehicleOutput>>(vehicles);

            _outputPort
                .StandardHandle(
                    new VehicleCollectionOutput(vehicleOutputs));
        }
    }
}
