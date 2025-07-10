using MediatR;
using Microsoft.AspNetCore.Mvc;
using SOSUrbano.Domain.Commands.CommandsAdmin.AdminReportsCommands.ListInfosReport;

namespace SOSUrbano.WebApi.Controllers.DashboardController
{
    [ApiController]
    [Route("[controller]")]
    public class AdminInfosReportController (ISender mediator) : ControllerBase
    {
        [HttpGet("getAdminInfosReport")]
        public async Task<IActionResult> GetAdminInfosReport([FromQuery] ListInfosReportRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
