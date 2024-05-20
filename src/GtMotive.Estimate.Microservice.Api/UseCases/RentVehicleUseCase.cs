using System;
using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.Api.Presenters.Interfaces;
using GtMotive.Estimate.Microservice.ApplicationCore.Inputs;
using GtMotive.Estimate.Microservice.ApplicationCore.Outputs;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.Domain.Enums;
using GtMotive.Estimate.Microservice.Infrastructure.Interfaces;

namespace GtMotive.Estimate.Microservice.Api.UseCases
{
    public class RentVehicleUseCase : IRentVehicleUseCase<RentVehicleInput>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IRentVehiclePresenter _outputPort;
        private readonly IMapper _mapper;

        public RentVehicleUseCase(
            IVehicleRepository vehicleRepository,
            IRentVehiclePresenter outputPort,
            IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _outputPort = outputPort;
            _mapper = mapper;
        }

        public async Task Execute(RentVehicleInput input)
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            var carAlreadyRentedByClient =
                await _vehicleRepository.GetVehicleByRented(input.RentedBy);

            if (carAlreadyRentedByClient is not null)
            {
                BuildBadRequestOutput(input, carAlreadyRentedByClient.Id);

                return;
            }

            var vehicle =
                await _vehicleRepository.GetAsync(input.Id);

            if (vehicle is null)
            {
                BuildNotFoundOutput(input);

                return;
            }

            if (vehicle.Status != VehicleStatusType.Available)
            {
                BuildBadRequestOutput(vehicle.Id);

                return;
            }

            vehicle.RentedBy = input.RentedBy;

            await _vehicleRepository.UpdateAsync(vehicle.Id, vehicle);

            _outputPort.StandardHandle(_mapper.Map<VehicleOutput>(vehicle));
        }

        private void BuildBadRequestOutput(RentVehicleInput input, Guid alreadyRentedVehicleId) =>
            _outputPort.BadRequestHandle(
                $"Client '{input.RentedBy}' has already rented a " +
                $"vehicle (id: {alreadyRentedVehicleId})");

        private void BuildBadRequestOutput(Guid vehicleId) =>
            _outputPort.BadRequestHandle(
                $"Vehicle with id {vehicleId} is not available right " +
                $"now for renting");

        private void BuildNotFoundOutput(RentVehicleInput input) =>
            _outputPort.NotFoundHandle(
                $"Vehicle with id {input.Id} cannot be found");
    }
}
