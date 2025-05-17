using MediatR;
using Microsoft.AspNetCore.Mvc;
using SOSUrbano.Domain.Comands.UserTypeComands.Create;
using SOSUrbano.Domain.Comands.UserTypeComands.List;
using SOSUrbano.Domain.Entities.UserEntity;

namespace SOSUrbano.WebApi.Controllers.UserControllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserTypeController(ISender mediator) : ControllerBase
    {
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllUserTypes()
        {
            var request = new ListUserTypesRequest();
            var response = await mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUserType
            (CreateUserTypeRequest request)
        {
            var response = await mediator.Send(request);
            return Created("Created", $"{response.Id} - {response.Message}");
        }
    }
}
