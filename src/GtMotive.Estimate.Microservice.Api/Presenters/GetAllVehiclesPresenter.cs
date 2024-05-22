using System.Collections.Generic;
using AutoMapper;
using GtMotive.Estimate.Microservice.Api.Presenters.Interfaces;
using GtMotive.Estimate.Microservice.Api.ViewModels;
using GtMotive.Estimate.Microservice.ApplicationCore.Outputs;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Presenters
{
    internal class GetAllVehiclesPresenter : IGetAllVehiclePresenter
    {
        private readonly IMapper _mapper;

        public GetAllVehiclesPresenter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult ActionResult { get; private set; } = null!;

        public void StandardHandle(VehicleCollectionOutput response)
        {
            var mappedResponse =
                _mapper.Map<List<VehicleResponse>>(response.ToList());

            ActionResult =
                new OkObjectResult(mappedResponse);
        }
    }
}
