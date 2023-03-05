using MetricsManager.Models.Requests;

namespace MetricsManager.Services.Client
{
    public interface IDotNetMetricsAgentClient
    {
        DotNetMetricsResponse GetDotNetMetrics(DotNetMetricsRequest request);
    }
}
