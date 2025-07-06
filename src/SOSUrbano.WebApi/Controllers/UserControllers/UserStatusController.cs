using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SOSUrbano.Domain.Commands.CommandsUser.UserStatusCommands.Create;
using SOSUrbano.Domain.Commands.CommandsUser.UserStatusCommands.Delete;
using SOSUrbano.Domain.Commands.CommandsUser.UserStatusCommands.List;
using SOSUrbano.Domain.Commands.CommandsUser.UserStatusCommands.Update;

namespace SOSUrbano.WebApi.Controllers.UserControllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserStatusController(ISender mediator) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllUserStatuses()
        {
            var request = new ListUserStatusRequest();
            var response = await mediator.Send(request);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<IActionResult> CreateUserStatus
            (CreateUserStatusRequest request)
        {
            var response = await mediator.Send(request);
            return Created("Created", response);
        }

        [AllowAnonymous]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateUserStatus
            (UpdateUserStatusRequest request)
        {
            var response = await mediator.Send(request);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserStatus(Guid id)
        {
            var request = new DeleteUserStatusRequest(id);

            var response = await mediator.Send(request);

            return Ok(response);
        }
    }
}
