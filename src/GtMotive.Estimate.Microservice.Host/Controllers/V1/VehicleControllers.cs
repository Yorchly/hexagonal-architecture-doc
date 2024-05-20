using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.Api.Requests;
using GtMotive.Estimate.Microservice.Api.ViewModels;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Infrastructure.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Host.Controllers.V1
{
    [ApiController]
    [Route("[controller]")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class VehicleControllers : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public VehicleControllers(
            IMediator mediator, IVehicleRepository vehicleRepository, IMapper mapper)
        {
            _mediator = mediator;
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var presenter =
                await _mediator.Send(new GetAllVehiclesRequest());

            return presenter.ActionResult;
        }

        [HttpPost]
        public async Task<IActionResult> Post(VehicleResponse vehicleResponse)
        {
            var vehicle = _mapper.Map<Vehicle>(vehicleResponse);

            await _vehicleRepository.CreateAsync(vehicle);

            return Ok();
        }
    }
}
