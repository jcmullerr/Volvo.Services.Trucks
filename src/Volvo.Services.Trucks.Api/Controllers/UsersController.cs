using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Volvo.Services.Trucks.Domain.Commands.Users.Add;

namespace Volvo.Services.Trucks.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
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