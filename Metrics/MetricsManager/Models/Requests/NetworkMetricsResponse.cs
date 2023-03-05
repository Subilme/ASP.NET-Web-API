using System.Text.Json.Serialization;

namespace MetricsManager.Models.Requests
{
    public class NetworkMetricsResponse
    {
        public int AgentId { get; set; }

        [JsonPropertyName("metrics")]
        public CPUMetric[] Metrics { get; set; }
    }
}
