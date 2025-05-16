using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SOSUrbano.Domain.Comands.UserComands.Create;
using SOSUrbano.Domain.Comands.UserComands.Delete;
using SOSUrbano.Domain.Comands.UserComands.Get;
using SOSUrbano.Domain.Comands.UserComands.List;

namespace SOSUrbano.WebApi.Controllers.UserControllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController(ISender mediator) : ControllerBase
    {
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllUsers()
        {
            var request = new ListUserRequest();
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var request = new GetUserRequest(id);
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser(CreateUserRequest request)
        {
            var response = await mediator.Send(request);
            
            return Created("Created", $"{response.Message} - {response.Id}");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var request = new DeleteUserRequest(id);
            var response = await mediator.Send(request);
            return Ok(response.Message);
        }
    }
}
