using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Volvo.Services.Trucks.Domain.Commands.Users.Add;

namespace Volvo.Services.Trucks.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> InsertUser(
            AddUserCommand command
        )
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}