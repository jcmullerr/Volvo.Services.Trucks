using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Volvo.Services.Trucks.Domain.Commands.Login;

namespace Volvo.Services.Trucks.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Login(
            LoginCommand command
        )
        {
            var token = await _mediator.Send(command);
            return Ok(new { token });
        }
    }
}
