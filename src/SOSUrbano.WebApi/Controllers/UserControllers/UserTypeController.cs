using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SOSUrbano.Domain.Comands.ComandsUser.UserTypeComands.Create;
using SOSUrbano.Domain.Comands.ComandsUser.UserTypeComands.Delete;
using SOSUrbano.Domain.Comands.ComandsUser.UserTypeComands.List;
using SOSUrbano.Domain.Comands.ComandsUser.UserTypeComands.Update;

namespace SOSUrbano.WebApi.Controllers.UserControllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserTypeController(ISender mediator) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllUserTypes()
        {
            var request = new ListUserTypesRequest();
            var response = await mediator.Send(request);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<IActionResult> CreateUserType
            (CreateUserTypeRequest request)
        {
            var response = await mediator.Send(request);
            return Created("Created", response);
        }

        [AllowAnonymous]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateUserType
            (UpdateUserTypeRequest request)
        {
            var response = await mediator.Send(request);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserType(Guid id)
        {
            var request = new DeleteUserTypeRequest(id);

            var response = await mediator.Send(request);

            return Ok(response);
        }
    }
}
