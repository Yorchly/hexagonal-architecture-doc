using AutoMapper;
using GtMotive.Estimate.Microservice.Api.Presenters.Interfaces;
using GtMotive.Estimate.Microservice.Api.ViewModels;
using GtMotive.Estimate.Microservice.ApplicationCore.Outputs;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Presenters
{
    public class ReturnVehiclePresenter : IReturnVehiclePresenter
    {
        private readonly IMapper _mapper;

        public ReturnVehiclePresenter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult ActionResult { get; private set; } = null!;

        public void BadRequestHandle(string message) =>
            ActionResult = new BadRequestObjectResult(message);

        public void NotFoundHandle(string message) =>
            ActionResult = new NotFoundObjectResult(message);

        public void StandardHandle(VehicleOutput response)
        {
            var vehicleResponse =
                _mapper.Map<VehicleResponse>(response);

            ActionResult = new OkObjectResult(vehicleResponse);
        }
    }
}
