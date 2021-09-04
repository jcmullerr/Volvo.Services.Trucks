using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volvo.Services.Trucks.Domain.Commands.Trucks.Add;
using Volvo.Services.Trucks.Domain.Commands.Trucks.Delete;
using Volvo.Services.Trucks.Domain.Commands.Trucks.Get.Many;
using Volvo.Services.Trucks.Domain.Commands.Trucks.Get.Single;
using Volvo.Services.Trucks.Domain.Commands.Trucks.Update;

namespace Volvo.Services.Trucks.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class TrucksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TrucksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> InsertTruck(
            AddTruckCommand command
        )
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTruck(
            UpdateTruckCommand command
        )
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTruck(long id)
        {
            await _mediator.Send(new DeleteTruckCommand(id));
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTruck(long id)
        {
            return Ok(await _mediator.Send(new GetSingleTruckCommand(id)));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTruck()
        {
            return Ok(await _mediator.Send(new GetManyTrucksCommand()));
        }
    }
}