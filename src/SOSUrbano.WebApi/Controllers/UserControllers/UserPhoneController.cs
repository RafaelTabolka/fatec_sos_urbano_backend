using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SOSUrbano.Domain.Commands.CommandsUser.UserPhoneCommands.Update;

namespace SOSUrbano.WebApi.Controllers.UserControllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserPhoneController(ISender mediator) : ControllerBase
    {
        [AllowAnonymous]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateUserPhone
            (UpdateUserPhoneRequest request)
        {
            var response = await mediator.Send(request);

            return Ok(response);
        }
    }
}
