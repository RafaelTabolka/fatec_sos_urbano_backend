using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionCommands.Create;
using SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionCommands.Delete;
using SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionCommands.Get;
using SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionCommands.List;
using SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionCommands.Update;

namespace SOSUrbano.WebApi.Controllers.InstitutionControllers
{
    [Route("[controller]")]
    [ApiController]
    public class InstitutionController(ISender mediator) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllInstitutions()
        {
            var request = new ListInstitutionRequest();
            var response = await mediator.Send(request);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInstitutionById(Guid id)
        {
            var request = new GetInstitutionRequest(id);

            var response = await mediator.Send(request);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<IActionResult> CreateInstitution
            (CreateInstitutionRequest request)
        {
            var response = await mediator.Send(request);

            return Created("Created: ", response);
        }

        [AllowAnonymous]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateInstitution
            (UpdateInstitutionRequest request)
        {
            var response = await mediator.Send(request);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstitution(Guid id)
        {
            var request = new DeleteInstitutionRequest(id);

            var response = await mediator.Send(request);

            return Ok(response);
        }
    }
}
