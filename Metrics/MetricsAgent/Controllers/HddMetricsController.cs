using MetricsAgent.Models.Requests;
using MetricsAgent.Models;
using MetricsAgent.Services;
using MetricsAgent.Services.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/hdd")]
    [ApiController]
    public class HddMetricsController : ControllerBase
    {
        private readonly ILogger<HddMetricsController> _logger;
        private readonly IHddMetricsRepository _hddMetricsRepository;

        public HddMetricsController(ILogger<HddMetricsController> logger, IHddMetricsRepository hddMetricsRepository)
        {
            _logger = logger;
            _hddMetricsRepository = hddMetricsRepository;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] HddMetricCreateRequest request)
        {
            _logger.LogInformation("Create hdd metric.");
            _hddMetricsRepository.Create(new HddMetric
            {
                Value = request.Value,
                Time = (long)request.Time.TotalSeconds
            });
            return Ok();
        }

        [HttpGet("from/{fromTime}/to/{toTime}")]
        public ActionResult<IList<HddMetric>> GetHDDMetrics([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation("Get hdd metrics call.");
            return Ok(_hddMetricsRepository.GetByTimePeriod(fromTime, toTime));
        }
    }
}
