using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionStatusCommands.Create;
using SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionStatusCommands.Delete;
using SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionStatusCommands.List;
using SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionStatusCommands.Update;

namespace SOSUrbano.WebApi.Controllers.InstitutionControllers
{
    [Route("[controller]")]
    [ApiController]
    public class InstitutionStatusController(ISender mediator) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllInstitutionStatuses()
        {
            var request = new ListInstitutionStatusesRequest();
            var response = await mediator.Send(request);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<IActionResult> CreateInstitutionStatus
            (CreateInstitutionStatusRequest request)
        {
            var response = await mediator.Send(request);

            return Created("Created: ", response);
        }

        [AllowAnonymous]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateInstitutionStatus
            (UpdateInstitutionStatusRequest request)
        {
            var response = await mediator.Send(request);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstitutionStatus(Guid id)
        {
            var request = new DeleteInstitutionStatusRequest(id);

            var response = await mediator.Send(request);

            return Ok(response);
        }
    }
}
