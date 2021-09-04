using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Volvo.Services.Trucks.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrucksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TrucksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> InsertTruck()
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTruck()
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTruck()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTruck()
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTruck()
        {
            return Ok();
        }
    }
}