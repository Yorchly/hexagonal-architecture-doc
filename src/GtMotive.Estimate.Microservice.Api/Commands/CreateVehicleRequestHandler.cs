using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.Api.Presenters.Interfaces;
using GtMotive.Estimate.Microservice.Api.Requests;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.Inputs;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.Commands
{
    public class CreateVehicleRequestHandler
        : IRequestHandler<CreateVehicleRequest, IWebApiPresenter>
    {
        private readonly ICreateVehicleUseCase<VehicleInput> _useCase;
        private readonly ICreateVehiclePresenter _presenter;
        private readonly IMapper _mapper;

        public CreateVehicleRequestHandler(
            ICreateVehicleUseCase<VehicleInput> useCase,
            ICreateVehiclePresenter presenter,
            IMapper mapper)
        {
            _useCase = useCase;
            _presenter = presenter;
            _mapper = mapper;
        }

        public async Task<IWebApiPresenter> Handle(
            CreateVehicleRequest request, CancellationToken cancellationToken)
        {
            var vehicleInput = _mapper.Map<VehicleInput>(request);

            await _useCase.Execute(vehicleInput);

            return _presenter;
        }
    }
}
