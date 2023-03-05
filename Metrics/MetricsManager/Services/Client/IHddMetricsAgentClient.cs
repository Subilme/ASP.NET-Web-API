using MetricsManager.Models.Requests;

namespace MetricsManager.Services.Client
{
    public interface IHddMetricsAgentClient
    {
        HddMetricsResponse GetHddMetrics(HddMetricsRequest request);
    }
}
