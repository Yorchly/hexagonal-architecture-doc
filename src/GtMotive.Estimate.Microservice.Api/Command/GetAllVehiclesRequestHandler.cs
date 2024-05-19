using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Requests;
using GtMotive.Estimate.Microservice.Api.UseCases;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.Command
{
    internal class GetAllVehiclesRequestHandler
        : IRequestHandler<GetAllVehiclesRequest, IWebApiPresenter>
    {
        public Task<IWebApiPresenter> Handle(GetAllVehiclesRequest request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
