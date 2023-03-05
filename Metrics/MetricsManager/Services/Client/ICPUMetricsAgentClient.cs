using MetricsManager.Models.Requests;

namespace MetricsManager.Services.Client
{
    public interface ICPUMetricsAgentClient
    {
        CPUMetricsResponse GetCPUMetrics(CPUMetricsRequest request);
    }
}
