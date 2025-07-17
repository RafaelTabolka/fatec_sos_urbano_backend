using MediatR;
using Microsoft.AspNetCore.Mvc;
using SOSUrbano.Domain.Commands.CommandsAdmin.AdminUsersCommands.ListUsers;

namespace SOSUrbano.WebApi.Controllers.AdminControllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminUsersController(ISender mediator) : ControllerBase
    {
        [HttpGet("listUsers")]
        public async Task<IActionResult> ListUsers([FromQuery] ListUsersForAdminRequest request)
        {
            var response = await mediator.Send(request);

            return Ok(response);
        }
    }
}
