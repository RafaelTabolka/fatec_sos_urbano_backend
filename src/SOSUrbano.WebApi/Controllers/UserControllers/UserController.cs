using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SOSUrbano.Domain.Comands.ComandsUser.UserComands.Create;
using SOSUrbano.Domain.Comands.ComandsUser.UserComands.Delete;
using SOSUrbano.Domain.Comands.ComandsUser.UserComands.Get;
using SOSUrbano.Domain.Comands.ComandsUser.UserComands.List;

namespace SOSUrbano.WebApi.Controllers.UserControllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController(ISender mediator) : ControllerBase
    {
        //[Authorize(Roles = "admin")]
        [AllowAnonymous]
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllUsers()
        {
            var request = new ListUserRequest();
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var request = new GetUserRequest(id);
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<IActionResult> CreateUser(CreateUserRequest request)
        {
            var response = await mediator.Send(request);
            
            return Created("Created", response);
        }

        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var request = new DeleteUserRequest(id);
            var response = await mediator.Send(request);
            return Ok(response.Message);
        }
    }
}
