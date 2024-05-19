using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.Outputs;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Presenters
{
    internal class GetAllVehiclesPresenter :
        IWebApiPresenter, IGetAllVehicleOutputPort<VehicleOutput>
    {
        public IActionResult ActionResult => throw new System.NotImplementedException();

        public void StandardHandle(VehicleOutput response)
        {
            throw new System.NotImplementedException();
        }
    }
}
