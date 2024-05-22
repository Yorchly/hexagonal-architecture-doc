using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Host.Controllers.V1
{
    [ApiController]
    [Route("vehicle")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class VehicleControllers : ControllerBase
    {
        private readonly IMediator _mediator;

        public VehicleControllers(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var presenter =
                await _mediator.Send(new GetAllVehiclesRequest());

            return presenter.ActionResult;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateVehicleRequest request)
        {
            var presenter =
                await _mediator.Send(request);

            return presenter.ActionResult;
        }

        // TO-DO This should be a patch and use JsonPatch
        [HttpPut("{id}/rent")]
        public async Task<IActionResult> RentAVehicle(
            [FromBody] RentVehicleRequest request)
        {
            var presenter =
                await _mediator.Send(request);

            return presenter.ActionResult;
        }

        // TO-DO This should be a patch and use JsonPatch
        [HttpPut("{id}/return")]
        public async Task<IActionResult> ReturnVehicle(Guid id)
        {
            var presenter =
                await _mediator.Send(new ReturnVehicleRequest { Id = id });

            return presenter.ActionResult;
        }
    }
}
