using MetricsAgent.Models.Requests;
using MetricsAgent.Models;
using MetricsAgent.Services;
using MetricsAgent.Services.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MetricsAgent.Models.Dto;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/hdd")]
    [ApiController]
    public class HddMetricsController : ControllerBase
    {
        private readonly ILogger<HddMetricsController> _logger;
        private readonly IHddMetricsRepository _hddMetricsRepository;
        private readonly IMapper _mapper;

        public HddMetricsController(ILogger<HddMetricsController> logger, 
            IHddMetricsRepository hddMetricsRepository,
            IMapper mapper)
        {
            _logger = logger;
            _hddMetricsRepository = hddMetricsRepository;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] HddMetricCreateRequest request)
        {
            _logger.LogInformation("Create hdd metric.");
            _hddMetricsRepository.Create(_mapper.Map<HddMetric>(request));
            return Ok();
        }

        [HttpGet("from/{fromTime}/to/{toTime}")]
        public ActionResult<IList<HddMetricDto>> GetHDDMetrics([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation("Get hdd metrics call.");
            return Ok(_mapper.Map<IList<HddMetricDto>>(_hddMetricsRepository.GetByTimePeriod(fromTime, toTime)));
        }
    }
}
