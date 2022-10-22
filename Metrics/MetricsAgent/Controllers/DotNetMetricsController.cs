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
    [Route("api/metrics/dotnet")]
    [ApiController]
    public class DotNetMetricsController : ControllerBase
    {
        private readonly ILogger<DotNetMetricsController> _logger;
        private readonly IDotNetMetricsRepository _dotNetMetricsRepository;
        private readonly IMapper _mapper;

        public DotNetMetricsController(ILogger<DotNetMetricsController> logger, 
            IDotNetMetricsRepository dotNetMetricsRepository, 
            IMapper mapper)
        {
            _logger = logger;
            _dotNetMetricsRepository = dotNetMetricsRepository;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] DotNetMetricCreateRequest request)
        {
            _logger.LogInformation("Create dotnet metric.");
            _dotNetMetricsRepository.Create(_mapper.Map<DotNetMetric>(request));
            return Ok();
        }

        [HttpGet("from/{fromTime}/to/{toTime}")]
        public ActionResult<IList<DotNetMetricDto>> GetDotNetMetrics([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation("Get dotnet metrics call.");
            return Ok(_dotNetMetricsRepository.GetByTimePeriod(fromTime, toTime).Select(metric => _mapper.Map<DotNetMetricDto>(metric)).ToList());
        }
    }
}
