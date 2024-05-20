using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Presenters.Interfaces;
using GtMotive.Estimate.Microservice.Api.Requests;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.Command
{
    internal class GetAllVehiclesRequestHandler
        : IRequestHandler<GetAllVehiclesRequest, IWebApiPresenter>
    {
        private readonly IGetAllVehiclesUseCase _useCase;
        private readonly IGetAllVehiclePresenter _presenter;

        public GetAllVehiclesRequestHandler(
            IGetAllVehiclesUseCase useCase,
            IGetAllVehiclePresenter presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        public async Task<IWebApiPresenter> Handle(
            GetAllVehiclesRequest request,
            CancellationToken cancellationToken)
        {
            await _useCase.Execute();

            return _presenter;
        }
    }
}
