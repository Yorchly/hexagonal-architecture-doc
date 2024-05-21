using System;
using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.Api.Presenters.Interfaces;
using GtMotive.Estimate.Microservice.ApplicationCore.Inputs;
using GtMotive.Estimate.Microservice.ApplicationCore.Outputs;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Enums;
using GtMotive.Estimate.Microservice.Infrastructure.Interfaces;

namespace GtMotive.Estimate.Microservice.Api.UseCases
{
    public class CreateVehicleUseCase : ICreateVehicleUseCase<VehicleInput>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ICreateVehiclePresenter _outputPort;
        private readonly IMapper _mapper;

        public CreateVehicleUseCase(
            IVehicleRepository vehicleRepository,
            ICreateVehiclePresenter outputPort,
            IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _outputPort = outputPort;
            _mapper = mapper;
        }

        public async Task Execute(VehicleInput input)
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            var vehicleAlreadyExists =
                await VehicleAlreadyExists(input.Id);

            if (vehicleAlreadyExists)
            {
                _outputPort.BadRequestHandle(
                    $"Error: vehicle with id {input.Id} " +
                    $"already exists and cannot be created again.");

                return;
            }

            var vehicle = _mapper.Map<Vehicle>(input);
            vehicle.Status = VehicleStatusType.Available;

            await _vehicleRepository.CreateAsync(vehicle);

            _outputPort.StandardHandle(_mapper.Map<VehicleOutput>(vehicle));
        }

        private async Task<bool> VehicleAlreadyExists(Guid? vehicleId) =>
            vehicleId is not null &&
            vehicleId != Guid.Empty &&
            (await _vehicleRepository.GetAsync((Guid)vehicleId)) is not null;
    }
}
