using MediatR;
using Microsoft.AspNetCore.Mvc;
using SOSUrbano.Domain.Commands.CommandsAdmin.AdminReportsCommands.Get;

namespace SOSUrbano.WebApi.Controllers.DashboardController
{
    [ApiController]
    [Route("[controller]")]
    public class AdminReportsController (ISender mediator) : ControllerBase
    {
        [HttpPost("getAdminInfosReport")]
        public async Task<IActionResult> GetAdminInfosReport(GetAdminReportsRequest request)
        {
            var response = await mediator.Send(request);

            return Ok(response);
        }
    }
}
