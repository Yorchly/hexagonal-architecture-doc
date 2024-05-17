using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.Api.ViewModels;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Host.Controllers.V1
{
    [ApiController]
    [Route("[controller]")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class VehicleControllers : ControllerBase
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public VehicleControllers(IVehicleRepository vehicleRepository, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _vehicleRepository.GetAsync();

            return Ok(result);
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
