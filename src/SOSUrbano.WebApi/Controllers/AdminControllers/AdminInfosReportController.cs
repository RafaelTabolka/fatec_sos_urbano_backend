﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using SOSUrbano.Domain.Commands.CommandsAdmin.AdminInfosReportCommands.ListInfosReport;

namespace SOSUrbano.WebApi.Controllers.DashboardController
{
    [ApiController]
    [Route("[controller]")]
    public class AdminInfosReportController (ISender mediator) : ControllerBase
    {
        [HttpGet("getAdminInfosReport")]
        public async Task<IActionResult> ListAdminInfosReport([FromQuery] ListInfosReportRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
