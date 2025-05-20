using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SOSUrbano.Domain.Comands.ComandsUser.UserStatusComands.Create;
using SOSUrbano.Domain.Comands.ComandsUser.UserStatusComands.List;

namespace SOSUrbano.WebApi.Controllers.UserControllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserStatusController(ISender mediator) : ControllerBase
    {
        [Authorize(Roles = "admin")]
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllUserStatuses()
        {
            var request = new ListUserStatusRequest();
            var response = await mediator.Send(request);

            return Ok(response);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("create")]
        public async Task<IActionResult> CreateUserStatus
            (CreateUserStatusRequest request)
        {
            var response = await mediator.Send(request);
            return Created("Created", response);
        }
    }
}
