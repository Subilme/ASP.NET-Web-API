using MetricsAgent.Models.Dto;

namespace MetricsAgent.Models.Requests
{
    public class GetDotNetMetricsResponse
    {
        public List<DotNetMetricDto> Metrics { get; set; }
    }
}
