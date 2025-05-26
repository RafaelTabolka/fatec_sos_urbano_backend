using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SOSUrbano.Domain.Comands.ComandsIncident.IncidentPhotoComands.Update;

namespace SOSUrbano.WebApi.Controllers.IncidentControllers
{
    [ApiController]
    [Route("[controller]")]
    public class IncidentPhotoController(ISender mediator) : ControllerBase
    {
        [AllowAnonymous]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateIncidentPhoto
            (UpdateIncidentPhotoRequest request)
        {
            var response = await mediator.Send(request);

            return Ok(response);
        }
    }
}
