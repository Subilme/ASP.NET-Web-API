using System.Text.Json.Serialization;

namespace MetricsManager.Models
{
    public class DotNetMetric
    {
        [JsonPropertyName("value")]
        public int Value { get; set; }

        [JsonPropertyName("time")]
        public int Time { get; set; }
    }
}
