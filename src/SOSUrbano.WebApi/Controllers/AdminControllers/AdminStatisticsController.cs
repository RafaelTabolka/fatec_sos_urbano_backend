using MediatR;
using Microsoft.AspNetCore.Mvc;
using SOSUrbano.Domain.Commands.CommandsAdmin.AdminStatisticsCommands.ListStatistics;

namespace SOSUrbano.WebApi.Controllers.AdminControllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminStatisticsController(ISender mediator) : ControllerBase
    {
        [HttpGet("listStatistics")]
        public async Task<IActionResult> ListStatistics([FromQuery]ListStatisticsRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
