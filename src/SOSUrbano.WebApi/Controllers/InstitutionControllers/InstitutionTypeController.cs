using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionTypeComands.Create;
using SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionTypeComands.Delete;
using SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionTypeComands.List;
using SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionTypeComands.Update;

namespace SOSUrbano.WebApi.Controllers.InstitutionControllers
{
    [Route("[controller]")]
    [ApiController]
    public class InstitutionTypeController(ISender mediator) :
        ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllInstitutionTypes()
        {
            var request = new ListInstitutionTypeRequest();
            var response = await mediator.Send(request);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<IActionResult> CreateInstitutionType
            (CreateInstitutionTypeRequest request)
        {
            var response = await mediator.Send(request);

            return Created("Created: ", response);
        }

        [AllowAnonymous]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateInstitutionType
            (UpdateInstitutionTypeRequest request)
        {
            var response = await mediator.Send(request);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstitutionType(Guid id)
        {
            var request = new DeleteInstitutionTypeRequest(id);

            var response = await mediator.Send(request);

            return Ok(response);
        }
    }
}
