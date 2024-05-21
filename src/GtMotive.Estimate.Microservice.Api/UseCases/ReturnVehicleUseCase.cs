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
    public class ReturnVehicleUseCase : IReturnVehicleUseCase<ReturnVehicleInput>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IReturnVehiclePresenter _outputPort;
        private readonly IMapper _mapper;

        public ReturnVehicleUseCase(
            IVehicleRepository vehicleRepository,
            IReturnVehiclePresenter outputPort,
            IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _outputPort = outputPort;
            _mapper = mapper;
        }

        public async Task Execute(ReturnVehicleInput input)
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            var vehicle =
                await _vehicleRepository.GetAsync(input.Id);

            if (vehicle is null)
            {
                BuildNotFoundOutput(input);

                return;
            }
            else if (vehicle.Status != VehicleStatusType.Rented)
            {
                BuildBadRequestOutput(input);

                return;
            }

            vehicle.Status = VehicleStatusType.Available;
            vehicle.RentedBy = null;

            await _vehicleRepository.UpdateAsync(input.Id, vehicle);

            _outputPort.StandardHandle(
                _mapper.Map<VehicleOutput>(vehicle));
        }

        private void BuildNotFoundOutput(ReturnVehicleInput input) =>
            _outputPort.NotFoundHandle(
                $"Vehicle with id '{input.Id}' cannot be found");

        private void BuildBadRequestOutput(ReturnVehicleInput input) =>
            _outputPort.BadRequestHandle(
                $"Vehicle with id '{input.Id}' cannot be returned because " +
                $"its not rented.");
    }
}
