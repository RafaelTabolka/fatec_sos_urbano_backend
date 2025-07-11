using MediatR;
using Microsoft.AspNetCore.Mvc;
using SOSUrbano.Domain.Commands.CommandsAdmin.AdminManageIncidentsCommands.ListManageIncidents;

namespace SOSUrbano.WebApi.Controllers.AdminControllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminManageIncidentsController(ISender mediator) : ControllerBase
    {
        [HttpGet("getManageIncidents")]
        public async Task<IActionResult> GetManageIncidents([FromQuery] ListManageIncidentsRequest request)
        {
            var response = await mediator.Send(request);

            return Ok(response);
        }
    }
}
