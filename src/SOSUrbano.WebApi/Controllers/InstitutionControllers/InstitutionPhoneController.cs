using MediatR;
using Microsoft.AspNetCore.Mvc;
using SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionPhoneCommands.Update;

namespace SOSUrbano.WebApi.Controllers.InstitutionControllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstitutionPhoneController(ISender mediator) : ControllerBase
    {
        [HttpPut("update")]
        public async Task<IActionResult> UpdateInstitutionPhone
            (UpdateInstitutionPhoneRequest request)
        {
            var response = await mediator.Send(request);

            return Ok(response);
        }
    }
}
