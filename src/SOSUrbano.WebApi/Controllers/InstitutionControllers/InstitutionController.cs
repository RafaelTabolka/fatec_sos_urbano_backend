using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionComands.Create;
using SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionComands.Delete;
using SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionComands.Get;
using SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionComands.List;

namespace SOSUrbano.WebApi.Controllers.InstitutionControllers
{
    [Route("[controller]")]
    [ApiController]
    public class InstitutionController(ISender mediator) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllInstitutions()
        {
            var request = new ListInstitutionRequest();
            var response = await mediator.Send(request);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInstitutionById(Guid id)
        {
            var request = new GetInstitutionRequest(id);

            var response = await mediator.Send(request);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<IActionResult> CreateInstitution
            (CreateInstitutionRequest request)
        {
            var response = await mediator.Send(request);

            return Created("Created: ", response);
        }

        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstitution(Guid id)
        {
            var request = new DeleteInstitutionRequest(id);

            var response = await mediator.Send(request);

            return Ok(response);
        }
    }
}
