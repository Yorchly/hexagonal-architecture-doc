using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.Api.Presenters.Interfaces;
using GtMotive.Estimate.Microservice.Api.Requests;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.Inputs;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.Queries
{
    public class RentVehicleRequestHandler
        : IRequestHandler<RentVehicleRequest, IWebApiPresenter>
    {
        private readonly IRentVehicleUseCase<RentVehicleInput> _useCase;
        private readonly IRentVehiclePresenter _presenter;
        private readonly IMapper _mapper;

        public RentVehicleRequestHandler(
            IRentVehicleUseCase<RentVehicleInput> useCase,
            IRentVehiclePresenter presenter,
            IMapper mapper)
        {
            _useCase = useCase;
            _presenter = presenter;
            _mapper = mapper;
        }

        public async Task<IWebApiPresenter> Handle(
            RentVehicleRequest request, CancellationToken cancellationToken)
        {
            var vehicleInput = _mapper.Map<RentVehicleInput>(request);

            await _useCase.Execute(vehicleInput);

            return _presenter;
        }
    }
}
