using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SOSUrbano.Domain.Commands.CommandsIncident.IncidentCommands.Create;
using SOSUrbano.Domain.Commands.CommandsIncident.IncidentCommands.Delete;
using SOSUrbano.Domain.Commands.CommandsIncident.IncidentCommands.Get;
using SOSUrbano.Domain.Commands.CommandsIncident.IncidentCommands.List;
using SOSUrbano.Domain.Commands.CommandsIncident.IncidentCommands.Update;

namespace SOSUrbano.WebApi.Controllers.IncidentControllers
{
    [ApiController]
    [Route("[controller]")]
    public class IncidentController(ISender mediator) : ControllerBase
    {
        //[Authorize(Roles = "admin, comum")]
        [AllowAnonymous]
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllIncidents()
        {
            var request = new ListIncidentRequest();

            var response = await mediator.Send(request);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIncidentById(Guid id)
        {
            var request = new GetIncidentRequest(id);

            var response = await mediator.Send(request);

            return Ok(response);
        }

        //[Authorize(Roles = "admin,comum")]
        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<IActionResult> CreateIncident
            ([FromForm]CreateIncidentRequest request)
        {
            var response = await mediator.Send(request);

            return Created("Created: ", response);
        }

        [AllowAnonymous]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateIncident(UpdateIncidentRequest request)
        {
            var response = await mediator.Send(request);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncident(Guid id)
        {
            var request = new DeleteIncidentRequest(id);

            var response = await mediator.Send(request);

            return Ok(response);
        }
    }
}
