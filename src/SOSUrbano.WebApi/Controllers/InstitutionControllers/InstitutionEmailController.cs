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
        [HttpPut("update")]
        public async Task<IActionResult> UpdateInstitutionEmail(UpdateInstitutionEmailRequest request)
        {
            var response = await mediator.Send(request);

            return Ok(response);
        }
    }
}
