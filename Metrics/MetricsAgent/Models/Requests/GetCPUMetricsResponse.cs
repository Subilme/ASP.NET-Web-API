using MetricsAgent.Models.Dto;

namespace MetricsAgent.Models.Requests
{
    public class GetCPUMetricsResponse
    { 
        public List<CPUMetricDto> Metrics { get; set; }
    }
}
