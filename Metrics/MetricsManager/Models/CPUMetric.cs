﻿using System.Text.Json.Serialization;

namespace MetricsManager.Models
{
    public class CPUMetric
    {
        [JsonPropertyName("value")]
        public int Value { get; set; }

        [JsonPropertyName("time")]
        public int Time { get; set; }
    }
}
