using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SOSUrbano.Domain.Comands.ComandsIncident.IncidentComands.Create;

namespace SOSUrbano.WebApi.Controllers.IncidentControllers
{
    [ApiController]
    [Route("[controller]")]
    public class IncidentController(ISender mediator) : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<IActionResult> CreateIncident
            (CreateIncidentRequest request)
        {
            var response = await mediator.Send(request);

            return Created("Created: ", response);
        }
    }
}
