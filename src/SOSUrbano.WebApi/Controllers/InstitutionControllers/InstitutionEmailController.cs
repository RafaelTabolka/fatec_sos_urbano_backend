using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionEmailComands.Update;

namespace SOSUrbano.WebApi.Controllers.InstitutionControllers
{
    [Route("[controller]")]
    [ApiController]
    public class InstitutionEmailController(ISender mediator) : 
        ControllerBase
    {
        [AllowAnonymous]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInstitutionEmail(Guid id)
        {
            var request = new UpdateInstitutionEmailRequest(id);

            var resonse = await mediator.Send(request);

            return Ok(Response);
        }
    }
}
