using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SOSUrbano.Domain.Commands.CommandsUser.UserLoginCommands.Login;

namespace SOSUrbano.WebApi.Controllers.LoginControllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController(ISender mediator) : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("loginUser")]
        public async Task<IActionResult> LoginUser
            (string email, string password)
        {
            var request = new LoginUserRequest(email, password);
            var response = await mediator.Send(request);

            return Ok(response);
        }
    }
}
