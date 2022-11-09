﻿using MetricsManager.Models.Requests;
using MetricsManager.Services.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetricsManager.Controllers
{
    [Route("api/ram")]
    [ApiController]
    public class RamMetricsController : ControllerBase
    {
        private readonly ILogger<RamMetricsController> _logger;
        private IRamMetricsAgentClient _metricsAgentClient;

        public RamMetricsController(ILogger<RamMetricsController> logger,
            IRamMetricsAgentClient metricsAgentClient)
        {
            _logger = logger;
            _metricsAgentClient = metricsAgentClient;
        }

        //[HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}")]
        [HttpGet("get-all-by-id")]
        public ActionResult<RamMetricsResponse> GetMetricsFromAgent(
            [FromQuery] int agentId, [FromQuery] TimeSpan fromTime, [FromQuery] TimeSpan toTime)
        {
            return Ok(_metricsAgentClient.GetRamMetrics(new RamMetricsRequest
            {
                AgentId = agentId,
                FromTime = fromTime,
                ToTime = toTime
            }));
        }

        //[HttpGet("all/from/{fromTime}/to/{toTime}")]
        [HttpGet("get-all")]
        public IActionResult GetMetricsFromAll([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            return Ok();
        }
    }
}
