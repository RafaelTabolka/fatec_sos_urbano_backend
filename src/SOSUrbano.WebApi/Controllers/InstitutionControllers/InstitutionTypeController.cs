using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionTypeComands.Create;
using SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionTypeComands.List;

namespace SOSUrbano.WebApi.Controllers.InstitutionControllers
{
    [Route("[controller]")]
    [ApiController]
    public class InstitutionTypeController(ISender mediator) :
        ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllTypes()
        {
            var request = new ListInstitutionTypeRequest();
            var response = await mediator.Send(request);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<IActionResult> CreateType
            (CreateInstitutionTypeRequest request)
        {
            var response = await mediator.Send(request);

            return Created("Created: ", response);
        }
    }
}
