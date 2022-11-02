using MetricsManager.Models.Requests;

namespace MetricsManager.Services.Client
{
    public interface IRamMetricsAgentClient
    {
        RamMetricsResponse GetRamMetrics(RamMetricsRequest request);
    }
}
