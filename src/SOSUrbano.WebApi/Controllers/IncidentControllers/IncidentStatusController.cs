using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SOSUrbano.Domain.Commands.CommandsIncident.IncidentStatusCommands.Create;
using SOSUrbano.Domain.Commands.CommandsIncident.IncidentStatusCommands.Delete;
using SOSUrbano.Domain.Commands.CommandsIncident.IncidentStatusCommands.List;
using SOSUrbano.Domain.Commands.CommandsIncident.IncidentStatusCommands.Update;

namespace SOSUrbano.WebApi.Controllers.IncidentControllers
{
    [Route("[controller]")]
    [ApiController]
    public class IncidentStatusController(ISender mediator) : 
        ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllIncidentStatuses()
        {
            var request = new ListIncidentStatusRequest();

            var response = await mediator.Send(request);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<IActionResult> CreateIncidentStatus
            (CreateIncidentStatusRequest request)
        {
            var response = await mediator.Send(request);

            return Created("Created: ", response);
        }

        [AllowAnonymous]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateIncidentStatus
            (UpdateIncidentStatusRequest request)
        {
            var response = await mediator.Send(request);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncidentStatus(Guid id)
        {
            var request = new DeleteIncidentStatusRequest(id);
            var response = await mediator.Send(request);

            return Ok(response);
        }
    }
}
