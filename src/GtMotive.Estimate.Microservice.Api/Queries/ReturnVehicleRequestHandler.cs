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
    public class ReturnVehicleRequestHandler
        : IRequestHandler<ReturnVehicleRequest, IWebApiPresenter>
    {
        private readonly IReturnVehicleUseCase<ReturnVehicleInput> _useCase;
        private readonly IReturnVehiclePresenter _presenter;
        private readonly IMapper _mapper;

        public ReturnVehicleRequestHandler(
            IReturnVehicleUseCase<ReturnVehicleInput> useCase,
            IReturnVehiclePresenter presenter,
            IMapper mapper)
        {
            _useCase = useCase;
            _presenter = presenter;
            _mapper = mapper;
        }

        public async Task<IWebApiPresenter> Handle(
            ReturnVehicleRequest request, CancellationToken cancellationToken)
        {
            var vehicleInput = _mapper.Map<ReturnVehicleInput>(request);

            await _useCase.Execute(vehicleInput);

            return _presenter;
        }
    }
}
