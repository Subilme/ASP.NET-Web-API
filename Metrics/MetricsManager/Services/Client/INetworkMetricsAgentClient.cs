using MetricsManager.Models.Requests;

namespace MetricsManager.Services.Client
{
    public interface INetworkMetricsAgentClient
    {
        NetworkMetricsResponse GetNetworkMetrics(NetworkMetricsRequest request);
    }
}
