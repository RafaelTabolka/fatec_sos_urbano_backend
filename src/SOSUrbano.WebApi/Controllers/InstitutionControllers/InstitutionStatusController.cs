using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionStatusComands.Create;
using SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionStatusComands.List;
using SOSUrbano.Domain.Entities.InstitutionEntity;

namespace SOSUrbano.WebApi.Controllers.InstitutionControllers
{
    [Route("[controller]")]
    [ApiController]
    public class InstitutionStatusController(ISender mediator) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllStatuses()
        {
            var request = new ListInstitutionStatusesRequest();
            var response = await mediator.Send(request);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<IActionResult> CreateStatus
            (CreateInstitutionStatusRequest request)
        {
            var response = await mediator.Send(request);

            return Created("Created: ", response);
        }
    }
}
