using MetricsAgent.Models.Requests;
using MetricsAgent.Models;
using MetricsAgent.Services;
using MetricsAgent.Services.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/dotnet")]
    [ApiController]
    public class DotNetMetricsController : ControllerBase
    {
        private readonly ILogger<DotNetMetricsController> _logger;
        private readonly IDotNetMetricsRepository _dotNetMetricsRepository;

        public DotNetMetricsController(ILogger<DotNetMetricsController> logger, 
            IDotNetMetricsRepository dotNetMetricsRepository)
        {
            _logger = logger;
            _dotNetMetricsRepository = dotNetMetricsRepository;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] DotNetMetricCreateRequest request)
        {
            _logger.LogInformation("Create dotnet metric.");
            _dotNetMetricsRepository.Create(new DotNetMetric
            {
                Value = request.Value,
                Time = (long)request.Time.TotalSeconds
            });
            return Ok();
        }

        [HttpGet("from/{fromTime}/to/{toTime}")]
        public ActionResult<IList<DotNetMetric>> GetDotNetMetrics([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation("Get dotnet metrics call.");
            return Ok(_dotNetMetricsRepository.GetByTimePeriod(fromTime, toTime));
        }
    }
}
