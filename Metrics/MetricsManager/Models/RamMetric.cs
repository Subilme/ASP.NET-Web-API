using System.Text.Json.Serialization;

namespace MetricsManager.Models
{
    public class RamMetric
    {
        [JsonPropertyName("value")]
        public int Value { get; set; }

        [JsonPropertyName("time")]
        public int Time { get; set; }
    }
}
