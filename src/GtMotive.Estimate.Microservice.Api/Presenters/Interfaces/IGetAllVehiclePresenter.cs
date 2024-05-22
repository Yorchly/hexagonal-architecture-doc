using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.Outputs;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;

namespace GtMotive.Estimate.Microservice.Api.Presenters.Interfaces
{
    public interface IGetAllVehiclePresenter :
        IWebApiPresenter, IGetAllVehicleOutputPort<VehicleCollectionOutput>
    {
    }
}
