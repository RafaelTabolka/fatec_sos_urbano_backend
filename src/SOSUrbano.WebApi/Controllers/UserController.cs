using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SOSUrbano.Domain.Comands.UserComands.Create;

namespace SOSUrbano.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(ISender mediator) : ControllerBase
    {
        [HttpPost("createUser")]
        public async Task<IActionResult> CreateUser(CreateUserRequest request)
        {
            var response = await mediator.Send(request);
            
            return Created("Created", $"{response.Message} - {response.Id}");
        }
    }
}
